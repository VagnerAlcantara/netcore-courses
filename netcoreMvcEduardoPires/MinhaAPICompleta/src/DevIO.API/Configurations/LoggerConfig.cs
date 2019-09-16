using Elmah.Io.AspNetCore;
using Elmah.Io.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.API.Configurations
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
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
            return services;
        }
        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
