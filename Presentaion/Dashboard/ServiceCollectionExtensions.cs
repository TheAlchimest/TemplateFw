using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        /* public static IServiceCollection AddWebDependancies(this IServiceCollection services)
         {
             services.AddScoped<ICurrentUserService, CurrentUserService>();

             return services;
         }
         */
        public static IServiceCollection AddMultiLingualSupport(this IServiceCollection services)
        {
            services.AddLocalization(options => options.ResourcesPath = "Resources");


            CultureInfo[] supportedCultures = new[]
            {
                new CultureInfo("ar"),
                new CultureInfo("en")
            };

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                };
            });

            services.AddMvc()
                            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                            .AddDataAnnotationsLocalization();

            return services;
        }
    }

    public static class ApplicationBuilderExtensions
    {
        public static void UseAppRequestLocalization(this IApplicationBuilder app)
        {
            var cultureInfo = new CultureInfo("ar-EG");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            app.UseRequestLocalization();
           
        }
    }
}
