using Serilog;
using Serilog.Events;
using Serilog.Formatting.Display;
using Serilog.Sinks.Email;

namespace Eleven.OralExpert.API.Utilities
{
    public static class SerilogConfiguration
    {
        // TODO: Configurar o Zoho SMTP no painel administrativo.
        // Verificar registros MX/DNS do domínio e criar senha de aplicativo, se necessário.
        public static void ConfigureSerilog()
        {
           
            var emailOptions = new EmailSinkOptions
            {
                From = "root@eleven.expert",  
                To = ["marcelolynx@gmail.com"],  
                Host = "smtp.zoho.com",  
                Port = 587,  
                Credentials = new System.Net.NetworkCredential("root@eleven.expert", "MJ&mv@2024"), 
                Subject = new MessageTemplateTextFormatter("Log critico - OralExpert")  
            };

          
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()  
                .WriteTo.Email(
                    emailOptions, 
                    restrictedToMinimumLevel: LogEventLevel.Fatal  
                )
                .WriteTo.File(
                    "logs/log-.txt",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: LogEventLevel.Warning  
                )
                .CreateLogger();
        }
    }
}