using FoodOrderAPI.Security;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
