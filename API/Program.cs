using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Services;
using Domain.Entities;
using Infrastructure.Extentions;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
      {
        {
          new OpenApiSecurityScheme
          {
            Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              },
              Scheme = "oauth2",
              Name = "Bearer",
              In = ParameterLocation.Header,

            },
            new List<string>()
          }
        });

});
builder.Services.AddCors(options => options.AddPolicy(name: "AppOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));

builder.Services.ImplementPersistence(builder.Configuration);
builder.Services.ImplementAuthentication(builder.Configuration);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();
builder.Services.AddScoped<IFodderService, FodderService>();
builder.Services.AddScoped<IFodderRepository, FodderRepository>();
builder.Services.AddScoped<IInsectService, InsectService>();
builder.Services.AddScoped<IInsectRepository, InsectRepository>();
builder.Services.AddScoped<ILivingPlaceService, LivingPlaceService>();
builder.Services.AddScoped<ILivingPlaceRepository, LivingPlaceRepository>();
builder.Services.AddScoped<IInsectFodderService, InsectFodderService>();
builder.Services.AddScoped<IInsectFodderRepository, InsectFodderRepository>();
builder.Services.AddScoped<IInsectLivingPlaceService, InsectLivingPlaceService>();
builder.Services.AddScoped<IInsectLivingPlaceRepository, InsectLivingPlaceRepository>();
builder.Services.AddScoped<ILivingPlaceFodderService, LivingPlaceFodderService>();
builder.Services.AddScoped<ILivingPlaceFodderRepository, LivingPlaceFodderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AppOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
