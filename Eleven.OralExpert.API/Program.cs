using System.ComponentModel;
using Eleven.OralExpert.API.Configurations;
using Eleven.OralExpert.API.Middlewares;
using Eleven.OralExpert.API.Utilities;
using Eleven.OralExpert.API.Validators;
using Eleven.OralExpert.Infra.Data;
using Eleven.OralExpert.Infra.Interfaces;
using Eleven.OralExpert.Infra.Repository;
using Eleven.OralExpert.Services;
using Eleven.OralExpert.Services.Interfaces;
using Eleven.OralExpert.Services.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

SerilogConfiguration.ConfigureSerilog();
builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeAPIConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null; 
        options.JsonSerializerOptions.WriteIndented = true; 
    })
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserResponseDtoValidator>());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();




var app = builder.Build();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseMiddleware<ExceptionMiddleware>();
app.UseSerilogRequestLogging(); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
