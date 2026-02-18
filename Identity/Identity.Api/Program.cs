
using Identity.Api.Exceptions;
using Identity.Api.Logging;
using Identity.Application.Interfaces;
using Identity.Application.Services;
using Identity.Application.Settings;
using Identity.Domain.Entities;
using Identity.Infrastructure.MessageBroker;
using Identity.Infrastructure.Messaging;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenIddict.Abstractions;
using OpenIddict.Validation.AspNetCore;
using Serilog;
using StackExchange.Redis;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Identity.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ==========================
        // Read config from appsetting.json
        // ==========================
        var jwtCfg = builder.Configuration.GetSection("JwtSetting");
        var jwtSecret = jwtCfg["Secret"];
        var issuer = jwtCfg["Issuer"];
        var audience = jwtCfg["Audience"];
        var accessTokenMinute = int.Parse(jwtCfg["AccessTokenMinutes"] ?? "10");

        builder.Services
               .AddOptions<JwtSetting>()
               .Bind(builder.Configuration.GetSection("JwtSetting"))
               .ValidateOnStart();

        builder.Services
               .AddOptions<HttpSetting>()
               .Bind(builder.Configuration.GetSection("HttpSetting"))
               .ValidateOnStart();

        builder.Services
               .AddOptions<RabbitMqSetting>()
               .Bind(builder.Configuration.GetSection("RabbitMq"))
               .ValidateOnStart();

        // ==========================
        // Cache service setting
        // ==========================
        builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
        {
            var configuration = builder.Configuration.GetSection("Redis")["ConnectionString"] ?? "localhost:6379";
            return ConnectionMultiplexer.Connect(configuration);
        });

        // ==========================
        // RabbitMQ DI service setting
        // ==========================
        builder.Services.AddSingleton<IRabbitMqPersistentConnection, RabbitMqPersistentConnection>();
        builder.Services.AddScoped<IMessagePublisher, RabbitMqPublisher>();



        // ==========================
        // Setting Routing option
        // ==========================
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true; // optional
        });


        // ==========================
        // Database connection
        // ==========================
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("PostgresConnection"),
                npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));


        // ==========================
        // Add Controllers
        // ==========================
        builder.Services.AddControllers();

        // ==========================
        // Add Open ID
        // ==========================
        builder.Services.AddOpenIddict()
            .AddCore(options =>
            {
                options.UseEntityFrameworkCore()
                       .UseDbContext<AppDbContext>();
            })
            .AddServer(options =>
            {
                options.SetTokenEndpointUris("/connect/token");
                options.SetAuthorizationEndpointUris("/connect/authorize");


                // Flows
                options.AllowClientCredentialsFlow();
                options.AllowAuthorizationCodeFlow()
                       .RequireProofKeyForCodeExchange();
                options.AllowRefreshTokenFlow();

                // Scopes
                options.RegisterScopes("api", "api.read", "api.write");

                // Dev certificates (replace in production!)
                options.AddDevelopmentEncryptionCertificate()
                       .AddDevelopmentSigningCertificate();

                options.UseAspNetCore()
                       .EnableAuthorizationEndpointPassthrough()
                       .EnableTokenEndpointPassthrough();
     
            });

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        });

        builder.Services.AddOpenIddict()
            .AddValidation(options =>
            {
                options.UseLocalServer();
                options.UseAspNetCore();
            });


        // ==========================
        // Jwt Setting
        // ==========================
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret));

        // Add Authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            //options.RequireHttpsMetadata = true; // set false only for local dev
            //options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidIssuer = issuer,

                ValidateAudience = false,
                ValidAudience = audience,

                ValidateIssuerSigningKey = false,
                IssuerSigningKey = key,

                ValidateLifetime = false,
                ClockSkew = TimeSpan.FromSeconds(30)
            };

            options.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    Console.WriteLine("❌ AUTH FAILED:");
                    Console.WriteLine(context.Exception.ToString());
                    return Task.CompletedTask;
                },
                OnChallenge = context =>
                {
                    Console.WriteLine("❌ CHALLENGE ERROR:");
                    Console.WriteLine(context.Error);
                    Console.WriteLine(context.ErrorDescription);
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    Console.WriteLine("✅ TOKEN VALIDATED");
                    return Task.CompletedTask;
                }
            };
        });

        // ==========================
        // Add Authorization
        // ==========================

        builder.Services.AddAuthorization();


        // ==========================
        // Swagger Setting
        // ==========================
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //builder.Services.AddSwaggerGen();
        builder.Services.AddSwaggerGen(c =>
        {
            c.MapType<IFormFile>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "binary"
            });

            c.SwaggerDoc("v1", new() { Title = "Identity API", Version = "v1" });

            // Add JWT Authorization header
            c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                Description = "Please enter JWT with Bearer prefix. Example: Bearer {token}",
                Name = "Authorization",
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });
            c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                    {
                        {
                            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                            {
                                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                                {
                                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                        }
                    });

            c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    ClientCredentials = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri("https://localhost:7016/connect/token"),
                        Scopes = new Dictionary<string, string>
                {
                    { "api", "Access API" }
                }
                    }
                }
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "oauth2"
                }
            },
            new[] { "api" }
        }
    });
        });

        // ==========================
        // Logging Setting
        // ==========================
        // Read Serilog config from appsettings.json
        Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
            .Enrich.With<LogSetting>()
            .Enrich.FromLogContext()        // important
            .CreateLogger();

        // Replace default logging with Serilog
        builder.Host.UseSerilog();

        // ==========================
        // Adding App Dependency Injection
        // ==========================
        // DI
        builder.Services.AddHttpClient();
        builder.Services.AddScoped<ICache, CacheRepository>();
        builder.Services.AddTransient<ExceptionHandlingMiddleware>();

        // DI Service
        builder.Services.AddScoped<IAuth, AuthService>();
        builder.Services.AddScoped<IRole,RoleService>();
        builder.Services.AddScoped<IOperator,OperatorService>();

        // DI Repository
        builder.Services.AddScoped<IRoleRepository,RoleRepository>();
        builder.Services.AddScoped<IOperatorRepository,OperatorRepository>();
        builder.Services.AddScoped<IOperatorRepository, OperatorRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<ITokenRepository, TokenRepository>();
        builder.Services.AddScoped<IHttpRepository, HttpRepository>();

        var app = builder.Build();

        await SeedClientsAsync(app);

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Identity API v1");

                options.OAuthClientId("thirdparty_app");
                options.OAuthClientSecret("super_secret");
                options.OAuthUsePkce(); // only needed for auth code flow
            });
        }

        // This logs every HTTP request automatically
        app.UseSerilogRequestLogging();

        app.UseHttpsRedirection();

        app.Use(async (context, next) =>
        {
            var authHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            Console.WriteLine("AUTH HEADER: " + authHeader);
            await next();
        });

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

      
        app.Run();

        async Task SeedClientsAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var manager = scope.ServiceProvider
                .GetRequiredService<IOpenIddictApplicationManager>();

            if (await manager.FindByClientIdAsync("thirdparty_app") == null)
            {
                await manager.CreateAsync(new OpenIddictApplicationDescriptor
                {
                    ClientId = "thirdparty_app",
                    ClientSecret = "super_secret",
                    Permissions =
            {
                OpenIddictConstants.Permissions.Endpoints.Token,
                OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                OpenIddictConstants.Permissions.Prefixes.Scope + "api"
            }
                });
            }
        }
    }
}
