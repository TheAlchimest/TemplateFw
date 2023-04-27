using Adoler.AdoExtension.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateFw.Persistence.IRepositories;
using TemplateFw.Persistence.Persistent.Db;
using TemplateFw.Persistence.Repositories;
using TemplateFw.Shared.Helpers.SqlDataHelpers;

namespace TemplateFw.Persistence
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            string dshboardConnection = configuration.GetSharedModulesWriteConnectionString();
            string dashboardReadOnlyConnection = configuration.GetSharedModulesReadOnlyConnectionString();

            services.AddDbContext<TemplateFwDbContext>(options => options.UseSqlServer(dshboardConnection));
            services.AddDbContext<DgReadOnlyDbContext>(options => options.UseSqlServer(dashboardReadOnlyConnection));

            services.AddScoped<Adoler.AdoExtension.Helpers.SqlDataHelper, Adoler.AdoExtension.Helpers.SqlDataHelper>(sp =>
            {
                return new SqlDataHelper(dshboardConnection);
            });

            services.AddScoped<SqlHelperWrite, SqlHelperWrite>(sp =>
            {
                return new SqlHelperWrite(configuration);
            });

            services.AddScoped<SqlHelperRead, SqlHelperRead>(sp =>
            {
                return new SqlHelperRead(configuration);
            });

            services.AddScoped<IDbHelper, DbHelper>();

            
			services.AddScoped<ICountryRepository, CountryRepository>();
			services.AddScoped<IFaqRepository, FaqRepository>();
			services.AddScoped<ILanguageRepository, LanguageRepository>();
			services.AddScoped<IPortalRepository, PortalRepository>();
			services.AddScoped<IServiceRepository, ServiceRepository>();
			services.AddScoped<IServiceTypeRepository, ServiceTypeRepository>();

            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<IActionLogRepository, ActionLogRepository>();

            return services;
        }
    }
}
