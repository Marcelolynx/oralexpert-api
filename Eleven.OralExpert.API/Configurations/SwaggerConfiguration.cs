using Microsoft.OpenApi.Models;

namespace Eleven.OralExpert.API.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "OralExpert API",
                Description = "API para gerenciamento de clínicas odontológicas.",
                Contact = new OpenApiContact
                {
                    Name = "Marcelo Oliveira",
                    Email = "contato@eleven.expert",
                    Url = new Uri("https://eleven.expert")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });

            options.EnableAnnotations();  
        });

        return services;
    }

    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseStaticFiles(); 
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.InjectStylesheet("/swagger-ui/swagger-custom.css");
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "OralExpert API v1");
            c.RoutePrefix = string.Empty;  
        });

        return app;
    }
}