using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TemplateFw.Application.Services.ActionLogs;

using TemplateFw.Application.Services;
using TemplateFw.Application.Services.Lookup;
using TemplateFw.Shared.Application.Services;
using TemplateFw.Shared.Configuration;
using TemplateFw.Dtos;

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
			services.AddTransient<ArticleDtoInsertValidator>();
			services.AddTransient<ArticleDtoUpdateValidator>();
			services.AddTransient<ArticleFilterValidator>();
			services.AddScoped<IAuthorService, AuthorService>();
			services.AddTransient<AuthorDtoInsertValidator>();
			services.AddTransient<AuthorDtoUpdateValidator>();
			services.AddTransient<AuthorFilterValidator>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddTransient<CategoryDtoInsertValidator>();
			services.AddTransient<CategoryDtoUpdateValidator>();
			services.AddTransient<CategoryFilterValidator>();
			services.AddScoped<ICommentService, CommentService>();
			services.AddTransient<CommentDtoInsertValidator>();
			services.AddTransient<CommentDtoUpdateValidator>();
			services.AddTransient<CommentFilterValidator>();
			services.AddScoped<IContactUsService, ContactUsService>();
			services.AddTransient<ContactUsDtoInsertValidator>();
			services.AddTransient<ContactUsDtoUpdateValidator>();
			services.AddTransient<ContactUsFilterValidator>();
			services.AddScoped<ICountryService, CountryService>();
			services.AddTransient<CountryDtoInsertValidator>();
			services.AddTransient<CountryDtoUpdateValidator>();
			services.AddTransient<CountryFilterValidator>();
			services.AddScoped<IFaqService, FaqService>();
			services.AddTransient<FaqDtoInsertValidator>();
			services.AddTransient<FaqDtoUpdateValidator>();
			services.AddTransient<FaqFilterValidator>();
			services.AddScoped<ILanguageService, LanguageService>();
			services.AddTransient<LanguageDtoInsertValidator>();
			services.AddTransient<LanguageDtoUpdateValidator>();
			services.AddTransient<LanguageFilterValidator>();
			services.AddScoped<IPaymentService, PaymentService>();
			services.AddTransient<PaymentDtoInsertValidator>();
			services.AddTransient<PaymentDtoUpdateValidator>();
			services.AddTransient<PaymentFilterValidator>();
			services.AddScoped<IPortalService, PortalService>();
			services.AddTransient<PortalDtoInsertValidator>();
			services.AddTransient<PortalDtoUpdateValidator>();
			services.AddTransient<PortalFilterValidator>();
			services.AddScoped<IServiceService, ServiceService>();
			services.AddTransient<ServiceDtoInsertValidator>();
			services.AddTransient<ServiceDtoUpdateValidator>();
			services.AddTransient<ServiceFilterValidator>();
			services.AddScoped<IServiceTypeService, ServiceTypeService>();
			services.AddTransient<ServiceTypeDtoInsertValidator>();
			services.AddTransient<ServiceTypeDtoUpdateValidator>();
			services.AddTransient<ServiceTypeFilterValidator>();
			services.AddScoped<ISubscriptionService, SubscriptionService>();
			services.AddTransient<SubscriptionDtoInsertValidator>();
			services.AddTransient<SubscriptionDtoUpdateValidator>();
			services.AddTransient<SubscriptionFilterValidator>();
			services.AddScoped<ISubscriptionPlanService, SubscriptionPlanService>();
			services.AddTransient<SubscriptionPlanDtoInsertValidator>();
			services.AddTransient<SubscriptionPlanDtoUpdateValidator>();
			services.AddTransient<SubscriptionPlanFilterValidator>();
			services.AddScoped<ISubscriptionStatusService, SubscriptionStatusService>();
			services.AddTransient<SubscriptionStatusDtoInsertValidator>();
			services.AddTransient<SubscriptionStatusDtoUpdateValidator>();
			services.AddTransient<SubscriptionStatusFilterValidator>();
			services.AddScoped<ITagService, TagService>();
			services.AddTransient<TagDtoInsertValidator>();
			services.AddTransient<TagDtoUpdateValidator>();
			services.AddTransient<TagFilterValidator>();
			services.AddScoped<IUsersService, UsersService>();
			services.AddTransient<UsersDtoInsertValidator>();
			services.AddTransient<UsersDtoUpdateValidator>();
			services.AddTransient<UsersFilterValidator>();
			
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
