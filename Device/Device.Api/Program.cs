using Device.Api.Logging;
using Device.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// ==========================
// Database connection
// ==========================
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgresConnection"),
        npgsqlOptions => npgsqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
        ));

// ==========================
// Seri Log Setting
// ==========================
// SeriLog
// Read Serilog config from appsettings.json
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration)
    .Enrich.With<LogSetting>()
    .Enrich.FromLogContext()        // important
    .CreateLogger();


// Replace default logging with Serilog
builder.Host.UseSerilog();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
