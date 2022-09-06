using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Book_API.AppStart
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book_API", Version = "v1" });
            });
        }

    }
}
