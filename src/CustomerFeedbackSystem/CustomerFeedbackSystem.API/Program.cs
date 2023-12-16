using CustomerFeedbackSystem.Application.Interfaces;
using CustomerFeedbackSystem.Application.Mappers;
using CustomerFeedbackSystem.Application.Services;
using CustomerFeedbackSystem.Domain.Models;
using CustomerFeedbackSystem.Infrastructure.Context;
using CustomerFeedbackSystem.Infrastructure.Interfaces;
using CustomerFeedbackSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//User defined Dependency Injection
builder.Services.AddSingleton<FeedbackContext>();
builder.Services.AddScoped<IRepo<Feedback,int>, FeedbackRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IFeedbackService, FeedbackService>();

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
