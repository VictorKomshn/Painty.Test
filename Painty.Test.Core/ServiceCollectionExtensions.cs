using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Painty.Test.Core.Abstract;
using Painty.Test.Core.Options;
using Painty.Test.Core.Services;

namespace Painty.Test.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<ImagesOptions>(x => config.GetSection(ImagesOptions.SectionName));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IImageService, ImageService>();
            return services;
        }
    }
}
