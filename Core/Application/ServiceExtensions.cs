using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TemplateFw.Application.Services.ActionLogs;

using TemplateFw.Application.Services;
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
			
            
			services.AddScoped<IArticleService, ArticleService>();
			services.AddScoped<IAuthorService, AuthorService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<ICommentService, CommentService>();
			services.AddScoped<IContactUsService, ContactUsService>();
			services.AddScoped<ICountryService, CountryService>();
			services.AddScoped<IFaqService, FaqService>();
			services.AddScoped<ILanguageService, LanguageService>();
			services.AddScoped<IPaymentService, PaymentService>();
			services.AddScoped<IPortalService, PortalService>();
			services.AddScoped<IServiceService, ServiceService>();
			services.AddScoped<IServiceTypeService, ServiceTypeService>();
			services.AddScoped<ISubscriptionService, SubscriptionService>();
			services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
			services.AddScoped<ISubscriptionStatusService, SubscriptionStatusService>();
			services.AddScoped<ITagService, TagService>();
			services.AddScoped<IUsersService, UsersService>();
			
            services.AddScoped<IUserInfoService, UserInfoService>();
            //services.AddScoped<IAttachmentService, AttachmentService>();
            services.AddScoped<ILookupService, LookupService>();
            services.AddScoped<IActionLogService, ActionLogService>();
            services.AddScoped<IActionLogService, ActionLogService>();
            return services;
        }
        #endregion


    }
}
