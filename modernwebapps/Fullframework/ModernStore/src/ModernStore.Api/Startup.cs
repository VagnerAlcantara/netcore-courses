using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ModernStore.Api.Security;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Infra.Contexts;
using ModernStore.Infra.Repositories;
using ModernStore.Infra.Services;
using ModernStore.Infra.Transations;
using System;
using System.Text;

namespace ModernStore.Api
{
    public class Startup
    {
        private const string ISSUER = "c1f51f42"; //nome qualuqer para gerar aplicação
        private const string AUDIENCE = "c6bbbb645024";//nome qualuqer para gerar aplicação
        private const string SECRET_KEY = "c1f51f42-5727-4d15-b787-c6bbbb645024";// chave da aplicação

        private readonly SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY));

        public void ConfigureServices(IServiceCollection services)
        {
            //Bloqueia todas ActionsResults, deixando-as apenas com acesso através do authorize, caso alguma tenha permissão para acesso anônimo, deixar
            // explicito com atribbute Anonymous.
            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                    .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            /*
             * Habilita o cors para o compartilhamento de recursos através de origin, 
             * para que possa ser utilizado em desenvolvimento, permitindo chamadas do localhost por exemplo
             * desabilitar para ambientes de produção
            */
            services.AddCors();

            //Adicionando as polyces
            //Policy é um contrato de autorização
            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireClaim("ModernStore", "User")); // Criando policy user que requer claim user
                options.AddPolicy("Admin", policy => policy.RequireClaim("ModernStore", "Admin"));
                /*options.AddPolicy("Admin", policy => {
                    // Fazer um request no banco por exemplo
                    //com está opção é possível colocar um código qualquer
                });*/
            });

            services.Configure<TokenOptions>(options =>
            {
                options.Issuer = ISSUER;
                options.Audience = AUDIENCE;
                options.SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256);
            });


            //AddScoped permanecer enquanto o Request durar, ou seja, apenas uma vez por request
            services.AddScoped<ModernStoreDataContext, ModernStoreDataContext>();

            //AddTransient sempre quando fizer nova instância, ou seja, várias vezes por request
            services.AddTransient<IUow, Uow>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IEmailService, EmailService>();

            services.AddTransient<CustomerCommandHandler, CustomerCommandHandler>();
            services.AddTransient<OrderCommandHandler, OrderCommandHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger)
        {
            logger.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = ISSUER,

                ValidateAudience = true,
                ValidAudience = AUDIENCE,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = _signingKey,

                RequireExpirationTime = true,
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero // resolve problemas no UTC
            };
            
            //app.UseJwtBearerAuthentication(app, new JwtBearerOptions
            //{
            //    //AutomaticAuthenticate = true,
            //    //AutomaticChallenge = true,
            //    TokenValidationParameters = tokenValidationParameters
            //});
            
            //usar na orde primeiro cors depois mvc
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();

        }
    }
}
