using Dashboard.Common.WebClientHelpers;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc.Razor;
using TemplateFw.Dashboard.Auth;
using TemplateFw.Dtos;
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
			services.SetWebClientHelpersConfigurations(webSettings.ModulesInternalApiUrl);
			services.AddControllersWithViews();

			services.AddWindowsAuth();

			var config = new SystemConfiguration();
			Configuration.Bind(config);
			services.AddSingleton(config);
			
			//Article
			services.AddTransient<ArticleDtoInsertValidator>();
			services.AddTransient<ArticleDtoUpdateValidator>();
			services.AddTransient<ArticleFilterValidator>();
			//Author
			services.AddTransient<AuthorDtoInsertValidator>();
			services.AddTransient<AuthorDtoUpdateValidator>();
			services.AddTransient<AuthorFilterValidator>();
			//Category
			services.AddTransient<CategoryDtoInsertValidator>();
			services.AddTransient<CategoryDtoUpdateValidator>();
			services.AddTransient<CategoryFilterValidator>();
			//Comment
			services.AddTransient<CommentDtoInsertValidator>();
			services.AddTransient<CommentDtoUpdateValidator>();
			services.AddTransient<CommentFilterValidator>();
			//ContactUs
			services.AddTransient<ContactUsDtoInsertValidator>();
			services.AddTransient<ContactUsDtoUpdateValidator>();
			services.AddTransient<ContactUsFilterValidator>();
			//Country
			services.AddTransient<CountryDtoInsertValidator>();
			services.AddTransient<CountryDtoUpdateValidator>();
			services.AddTransient<CountryFilterValidator>();
			//Faq
			services.AddTransient<FaqDtoInsertValidator>();
			services.AddTransient<FaqDtoUpdateValidator>();
			services.AddTransient<FaqFilterValidator>();
			//Language
			services.AddTransient<LanguageDtoInsertValidator>();
			services.AddTransient<LanguageDtoUpdateValidator>();
			services.AddTransient<LanguageFilterValidator>();
			//Model
			services.AddTransient<ModelDtoInsertValidator>();
			services.AddTransient<ModelDtoUpdateValidator>();
			services.AddTransient<ModelFilterValidator>();
			//ModelStatus
			services.AddTransient<ModelStatusDtoInsertValidator>();
			services.AddTransient<ModelStatusDtoUpdateValidator>();
			services.AddTransient<ModelStatusFilterValidator>();
			//Payment
			services.AddTransient<PaymentDtoInsertValidator>();
			services.AddTransient<PaymentDtoUpdateValidator>();
			services.AddTransient<PaymentFilterValidator>();
			//Portal
			services.AddTransient<PortalDtoInsertValidator>();
			services.AddTransient<PortalDtoUpdateValidator>();
			services.AddTransient<PortalFilterValidator>();
			//Service
			services.AddTransient<ServiceDtoInsertValidator>();
			services.AddTransient<ServiceDtoUpdateValidator>();
			services.AddTransient<ServiceFilterValidator>();
			//ServiceType
			services.AddTransient<ServiceTypeDtoInsertValidator>();
			services.AddTransient<ServiceTypeDtoUpdateValidator>();
			services.AddTransient<ServiceTypeFilterValidator>();
			//Subscription
			services.AddTransient<SubscriptionDtoInsertValidator>();
			services.AddTransient<SubscriptionDtoUpdateValidator>();
			services.AddTransient<SubscriptionFilterValidator>();
			//SubscriptionPlan
			services.AddTransient<SubscriptionPlanDtoInsertValidator>();
			services.AddTransient<SubscriptionPlanDtoUpdateValidator>();
			services.AddTransient<SubscriptionPlanFilterValidator>();
			//SubscriptionStatus
			services.AddTransient<SubscriptionStatusDtoInsertValidator>();
			services.AddTransient<SubscriptionStatusDtoUpdateValidator>();
			services.AddTransient<SubscriptionStatusFilterValidator>();
			//Tag
			services.AddTransient<TagDtoInsertValidator>();
			services.AddTransient<TagDtoUpdateValidator>();
			services.AddTransient<TagFilterValidator>();
			//Users
			services.AddTransient<UsersDtoInsertValidator>();
			services.AddTransient<UsersDtoUpdateValidator>();
			services.AddTransient<UsersFilterValidator>();

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
