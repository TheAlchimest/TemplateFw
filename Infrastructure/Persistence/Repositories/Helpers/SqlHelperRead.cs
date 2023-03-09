using Microsoft.Extensions.Configuration;
using TemplateFw.Shared.Helpers.SqlDataHelpers;

namespace TemplateFw.Persistence.Repositories
{
    public class SqlHelperRead : Adoler.SqlDataHelper
    {
        public SqlHelperRead(IConfiguration configuration) : base(configuration.GetSharedModulesReadOnlyConnectionString())
        {
        }

    }
}
