using Microsoft.Extensions.DependencyInjection;
using TemplateFw.Application.Services.FAQ;
using TemplateFw.Application.Services.Languages;
using System.Reflection;
using TemplateFw.Application.Services.Announces;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Application;
using TemplateFw.Shared.Configuration;
using TemplateFw.Application.Services.Countries;
using TemplateFw.Application.Services.Lookup;
using TemplateFw.Application.Services.ActionLogs;

namespace TemplateFw.Application
{
    public static class ServiceExtensions
    {

        #region AddAppilcationServices
        public static IServiceCollection AddAppilcationServices(this IServiceCollection services,
            string notificationUrl,  SystemConfiguration config)
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
