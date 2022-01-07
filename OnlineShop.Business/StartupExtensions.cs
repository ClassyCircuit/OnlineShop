using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Business.Helpers;
using OnlineShop.Business.Services;

namespace OnlineShop.Business
{
    public static class StartupExtensions
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ProductService>();
            services.AddScoped<ImageService>();
            services.AddScoped<HashingHelper>();
        }
    }
}
