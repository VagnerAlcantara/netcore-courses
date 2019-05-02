using FN.Store.Data.EF;
using FN.Store.Data.EF.Repositories;
using FN.Store.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FN.Store.DI
{
    public static class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            //Instancia única em todo o projeto
            //services.AddSingleton<StoreDataContext>();

            //Instancia por chamada
            //services.AddTransient<StoreDataContext>();

            //Instancia por requisição
            services.AddScoped<StoreDataContext>();
            //Instancia por chamada
            services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
        }
    }
}
