using Microsoft.Extensions.DependencyInjection;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Configuration;

namespace TemplateFw.Shared.Application
{
    public static class ServiceExtensions
    {

        #region AddSharedServices
        public static IServiceCollection AddSharedServices(this IServiceCollection services,
            SystemConfiguration config)
        {
            services.AddSingleton(config);
            services.AddScoped<IUserInfoService, UserInfoService>();
            return services;
        }
        #endregion


    }
}
