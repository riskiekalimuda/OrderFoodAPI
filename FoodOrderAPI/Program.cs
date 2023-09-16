using FoodOrderAPI.Security;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

app.UseMiddleware<BasicAuthHandler>("test");

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
