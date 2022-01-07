using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Data.DataManagers;

namespace OnlineShop.Data
{
    public static class StartupExtensions
    {
        public static void AddDataLayer(this IServiceCollection services)
        {
            services.AddScoped<ProductDataManager>();
            services.AddScoped<FileManager>();
        }
    }
}
