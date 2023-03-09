using TemplateFw.Persistence.Persistent.Db;

namespace TemplateFw.Persistence.Repositories
{
    public interface IDbHelper
    {
        DgReadOnlyDbContext dbReadOnly { get; }
        TemplateFwDbContext dbWrite { get; }
        string ReadConnectionString { get; }
        SqlHelperRead SqlHelperRead { get; }
        SqlHelperWrite SqlHelperWrite { get; }
        string WriteConnectionString { get; }
    }
}