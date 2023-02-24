using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TemplateFw.Persistence.Persistent.Db
{
    public partial class DgReadOnlyDbContext : TemplateFwDbContext {

        public DgReadOnlyDbContext(DbContextOptions<TemplateFwDbContext> options)
                : base(options)
        {
        }
    }



}
