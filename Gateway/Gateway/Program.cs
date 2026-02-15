using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;
using Yarp.ReverseProxy;

namespace Gateway;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var jwtSettings = builder.Configuration.GetSection("JwtSettings");

        // ==========================
        // Authentication
        // ==========================

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = jwtSettings["Authority"];
                options.Audience = jwtSettings["Audience"];
                options.RequireHttpsMetadata = false;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });

        builder.Host.UseSerilog((ctx, lc) =>
        {
            lc.WriteTo.Console();
        });

        // ==========================
        // Authorization Policies
        // ==========================
        builder.Services.AddAuthorization(options =>
        {
            // Used for internal users
            options.AddPolicy("UserPolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("role");
            });

            // Used for integration (OAuth client credentials)
            options.AddPolicy("IntegrationPolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireClaim("scope");
            });
        });



        // ==========================
        // YARP Reverse Proxy
        // ==========================

        builder.Services
           .AddReverseProxy()
           .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));


        builder.Services.AddCors(opt =>
        {
            opt.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        builder.Services.AddHealthChecks();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // Add services to the container.
        builder.Services.AddAuthorization();

        // ==========================
        // Rate Limit Policy
        // ==========================

        builder.Services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter("fixed", config =>
            {
                config.Window = TimeSpan.FromSeconds(10);
                config.PermitLimit = 100;
            });
        });

        var app = builder.Build();

        app.UseSerilogRequestLogging();
        app.UseCors("AllowAll");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseRateLimiter();

        app.MapHealthChecks("/health");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.MapReverseProxy();

        // Security headers
        app.Use(async (context, next) =>
        {
            context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
            context.Response.Headers.Add("X-Frame-Options", "DENY");
            await next();
        });


        app.Run();
    }
}
