using Dashboard.Common.WebClientHelpers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Razor;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Dtos;
using TemplateFw.Resources;
using TemplateFw.Shared.Configuration;

namespace TemplateFw.Dashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var webSettingsSection = Configuration.GetSection("WebSettings");
            services.Configure<WebSettings>(webSettingsSection);
            var webSettings = webSettingsSection.Get<WebSettings>();
            services.SetWebClientHelpersConfigurations(webSettings.ModulesInternalApiUrl, webSettings.AccountsInternalApiUrl);
            services.AddControllersWithViews();

            services.AddWindowsAuth();

            var config = new SystemConfiguration();
            Configuration.Bind(config);
            services.AddSingleton(config);
            services.AddTransient<FaqDtoInsertValidator, FaqDtoInsertValidator>();
            services.AddTransient<FaqDtoUpdateValidator, FaqDtoUpdateValidator>();

            services.AddTransient<CountryDtoInsertValidator, CountryDtoInsertValidator>();
            services.AddTransient<CountryDtoInsertValidator, CountryDtoUpdateValidator>();

            services.AddTransient<CountryDtoInsertValidator, CountryDtoInsertValidator>();
            services.AddTransient<CountryDtoUpdateValidator, CountryDtoUpdateValidator>();

            services.AddTransient<ServiceTypeDtoInsertValidator, ServiceTypeDtoInsertValidator>();
            services.AddTransient<ServiceTypeDtoUpdateValidator, ServiceTypeDtoUpdateValidator>();

            services.AddTransient<ArticleDtoInsertValidator, ArticleDtoInsertValidator>();
            services.AddTransient<ArticleDtoUpdateValidator, ArticleDtoUpdateValidator>();

            services.AddTransient<AuthorDtoInsertValidator, AuthorDtoInsertValidator>();
            services.AddTransient<AuthorDtoUpdateValidator, AuthorDtoUpdateValidator>();

            services.AddTransient<CategoryDtoInsertValidator, CategoryDtoInsertValidator>();
            services.AddTransient<CategoryDtoUpdateValidator, CategoryDtoUpdateValidator>();

            services.AddTransient<CommentDtoInsertValidator, CommentDtoInsertValidator>();
            services.AddTransient<CommentDtoUpdateValidator, CommentDtoUpdateValidator>();

            services.AddTransient<ContactUsDtoInsertValidator, ContactUsDtoInsertValidator>();
            services.AddTransient<ContactUsDtoUpdateValidator, ContactUsDtoUpdateValidator>();

            services.AddTransient<PaymentDtoInsertValidator, PaymentDtoInsertValidator>();
            services.AddTransient<PaymentDtoUpdateValidator, PaymentDtoUpdateValidator>();

            services.AddTransient<SubscriptionDtoInsertValidator, SubscriptionDtoInsertValidator>();
            services.AddTransient<SubscriptionDtoUpdateValidator, SubscriptionDtoUpdateValidator>();

            services.AddTransient<SubscriptionPlanDtoInsertValidator, SubscriptionPlanDtoInsertValidator>();
            services.AddTransient<SubscriptionPlanDtoUpdateValidator, SubscriptionPlanDtoUpdateValidator>();

            services.AddTransient<SubscriptionStatusDtoInsertValidator, SubscriptionStatusDtoInsertValidator>();
            services.AddTransient<SubscriptionStatusDtoUpdateValidator, SubscriptionStatusDtoUpdateValidator>();

            services.AddTransient<TagDtoInsertValidator, TagDtoInsertValidator>();
            services.AddTransient<TagDtoUpdateValidator, TagDtoUpdateValidator>();

            services.AddTransient<UsersDtoInsertValidator, UsersDtoInsertValidator>();
            services.AddTransient<UsersDtoUpdateValidator, UsersDtoUpdateValidator>();




            // Add Localizations
            services.AddLocalization();
            services.AddMvc(o =>
            {
                o.Conventions.Add(new AddAuthorizeFiltersControllerConvention());
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IValidator>())
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization()
            .AddJsonOptions(jsonOptions =>
            {
                jsonOptions.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            #region Log

            LogConfiguration.SetLogConfiguration(Configuration);

            #endregion

            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddDataAnnotationsLocalization()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePages(sub =>
            {
                sub.Run(async context =>
                {
                    if (context.Response.StatusCode == 403)
                    {
                        context.Response.Redirect("/Home/UnauthorizedAction");
                        await Task.CompletedTask;
                    }
                });
            });
            app.UseRequestLocalization();//to support multi languages

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //
            app.UseAppRequestLocalization();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "BlockReasonNote",
                   pattern: "{controller=Home}/{action=Index}/{id?}/{foundationType?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");


            });
        }
    }
}
