using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TemplateFw.Application.Services.ActionLogs;
using TemplateFw.Application.Services.Announces;
using TemplateFw.Application.Services.Countries;
using TemplateFw.Application.Services;
using TemplateFw.Application.Services.Languages;
using TemplateFw.Application.Services.Lookup;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Configuration;

namespace TemplateFw.Application
{
    public static class ServiceExtensions
    {

        #region AddAppilcationServices
        public static IServiceCollection AddAppilcationServices(this IServiceCollection services,
            string notificationUrl, SystemConfiguration config)
        {
            // Auto Mapper Configurations
            var mapperAssembly = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(mapperAssembly);
            services.AddScoped<IAnnounceService, AnnounceService>();
            services.AddScoped<IFaqService, FaqService>();
            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<IUserInfoService, UserInfoService>();
            //services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IActionLogService, ActionLogService>();
            services.AddScoped<IActionLogService, ActionLogService>();
            return services;
        }
        #endregion


    }
}
