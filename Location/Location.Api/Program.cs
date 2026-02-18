
using Location.Api.Exceptions;
using Location.Api.Logging;
using Location.Application.Interfaces;
using Location.Application.Services;
using Location.Application.Settings;
using Location.Infrastructure.Messaging;
using Location.Infrastructure.Persistence;
using Location.Infrastructure.Repositories;
using Location.Infrastructure.Workers;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

namespace Location.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // ==========================
        // Read config from appsetting.json
        // ==========================

        builder.Services
               .AddOptions<RabbitMqSetting>()
               .Bind(builder.Configuration.GetSection("RabbitMq"))
               .ValidateOnStart();

        // ==========================
        // Database connection
        // ==========================
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(
                builder.Configuration.GetConnectionString("PostgresConnection"),
                npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
                ));

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // ==========================
        // RabbitMQ DI service setting
        // ==========================
        builder.Services.AddSingleton<IRabbitMqPersistentConnection, RabbitMqPersistentConnection>();
        //builder.Services.AddScoped<IMessagePublisher, RabbitMqPublisher>();

        // ==========================
        // Dependency Injection
        // ==========================
        builder.Services.AddScoped<ILocation,LocationService>();
        builder.Services.AddScoped<ILocationRepository,LocationRepository>();
        builder.Services.AddSingleton<Workers>();
        builder.Services.AddHostedService(provider => provider.GetRequiredService<Workers>());

        // SeriLog
        // Read Serilog config from appsettings.json
        Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
            .Enrich.With<LogSetting>()
            .Enrich.FromLogContext()        // important
            .CreateLogger();

        // ==========================
        // Setting Routing option
        // ==========================
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
            options.LowercaseQueryStrings = true; // optional
        });

        // ==========================
        // Add Middleware
        // ==========================
        builder.Services.AddTransient<ExceptionHandlingMiddleware>();


        // ==========================
        // Seri Log Setting
        // ==========================
        // Replace default logging with Serilog
        builder.Host.UseSerilog();

        var app = builder.Build();

        app.UseMiddleware<ExceptionHandlingMiddleware>();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
