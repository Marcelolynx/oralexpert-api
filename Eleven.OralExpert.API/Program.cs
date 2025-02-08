using Eleven.OralExpert.API.Configurations;
using Eleven.OralExpert.API.Middlewares;
using Eleven.OralExpert.API.Utilities;
using Eleven.OralExpert.API.Validators;
using Eleven.OralExpert.Infra.Data;
using Eleven.OralExpert.Infra.Interfaces;
using Eleven.OralExpert.Infra.Repository;
using Eleven.OralExpert.Services;
using Eleven.OralExpert.Services.DTOs;
using Eleven.OralExpert.Services.Interfaces;
using Eleven.OralExpert.Services.Services;
using Eleven.OralExpert.Services.Validators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

SerilogConfiguration.ConfigureSerilog();
builder.Host.UseSerilog();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("A variável de ambiente 'DefaultConnection' não está configurada.");
}



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateTimeAPIConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.WriteIndented = true;
    })
    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UserResponseDtoValidator>());

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IValidator<UserRegisterDto>, UserRegisterDtoValidator>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

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
