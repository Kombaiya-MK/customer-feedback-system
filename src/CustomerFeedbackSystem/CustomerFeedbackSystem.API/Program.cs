using CustomerFeedbackSystem.Application.Interfaces;
using CustomerFeedbackSystem.Application.Mappers;
using CustomerFeedbackSystem.Application.Services;
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Context;
using CustomerFeedbackSystem.Infrastructure.Interfaces;
using CustomerFeedbackSystem.Infrastructure.Middleware;
using CustomerFeedbackSystem.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//User defined Dependency Injection
builder.Services.AddSingleton<FeedbackContext>();
builder.Services.AddScoped<IRepo<Feedback, int>, FeedbackRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

// Access configuration
var configuration = builder.Configuration;

builder.Services.AddStackExchangeRedisCache(opts =>
{
    opts.Configuration = configuration.GetConnectionString("cache-db");
    opts.InstanceName = "feedback-cache";
});

//Logger - Serilog
Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(builder.Configuration).CreateLogger();
builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Middlewares 

app.UseMiddleware<ApiKeyMiddleware>();

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


[ExcludeFromCodeCoverage]
public partial class Program { 
}
