using Microsoft.Extensions.Configuration;
using TemplateFw.Persistence.Persistent.Db;
using TemplateFw.Shared.Helpers.SqlDataHelpers;

namespace TemplateFw.Persistence.Repositories
{
    public class DbHelper : IDbHelper
    {
        public TemplateFwDbContext dbWrite { get; }
        public DgReadOnlyDbContext dbReadOnly { get; }
        public SqlHelperWrite SqlHelperWrite { get; }
        public SqlHelperRead SqlHelperRead { get; }
        public string WriteConnectionString { get; }
        public string ReadConnectionString { get; }

        public DbHelper(TemplateFwDbContext dbWrite, DgReadOnlyDbContext dbReadOnly, SqlHelperWrite dbHelperWrite, SqlHelperRead dbHelperRead, IConfiguration configuration)
        {
            this.dbWrite = dbWrite;
            this.dbReadOnly = dbReadOnly;
            SqlHelperWrite = dbHelperWrite;
            SqlHelperRead = dbHelperRead;
            WriteConnectionString = configuration.GetSharedModulesWriteConnectionString();
            ReadConnectionString = configuration.GetSharedModulesReadOnlyConnectionString();
        }

    }
}
