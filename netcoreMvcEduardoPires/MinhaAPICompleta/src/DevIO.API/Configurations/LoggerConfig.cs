using DevIO.Api.Extensions;
using Elmah.Io.AspNetCore;
using Elmah.Io.AspNetCore.HealthChecks;
using Elmah.Io.Extensions.Logging;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DevIO.API.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "51bac90981ae4c509a64fac5dd85cebd";
                o.LogId = new Guid("22cac726-fc0d-4a9b-b5c0-c2ef8a5affa1");
            });

            //Configuração para o Elmah utilizar o log padrão do asp net core 
            /*
            services.AddLogging(x =>
            {
                x.AddElmahIo(o =>
                {
                    o.ApiKey = "51bac90981ae4c509a64fac5dd85cebd";
                    o.LogId = new Guid("22cac726-fc0d-4a9b-b5c0-c2ef8a5affa1");
                });
                //Definindo que vai logar de warning pra pior, ou seja, por exemplo o info ele não vai logar
                x.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            });
            */

            services.AddHealthChecks()
                .AddElmahIoPublisher("388dd3a277cb44c4aa128b5c899a3106", new Guid("c468b2b8-b35d-4f1a-849d-f47b60eef096"), "API Fornecedores")
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            services.AddHealthChecksUI();

            return services;
        }
        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            app.UseHealthChecks("/api/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
            app.UseHealthChecksUI(options => { options.UIPath = "/api/hc-ui"; });

            return app;
        }
    }
}
