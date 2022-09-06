using BusinessTier;
using Microsoft.Extensions.DependencyInjection;

namespace Book_API.AppStart
{
    public static class ConfigureDependencyInjectionResolver
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
