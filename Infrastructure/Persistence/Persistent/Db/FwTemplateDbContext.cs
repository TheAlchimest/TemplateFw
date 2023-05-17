using Microsoft.EntityFrameworkCore;
using TemplateFw.Domain.Models;
using TemplateFw.Domain.Models.Countries;
using TemplateFw.Persistence.Persistent.Db.Configurations;

#nullable disable

namespace TemplateFw.Persistence.Persistent.Db
{
    public partial class TemplateFwDbContext : DbContext
    {
        public TemplateFwDbContext(DbContextOptions<TemplateFwDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public virtual DbSet<Language> Languages { get; set; }


        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<ActionLog> ActionLogs { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_100_CI_AS");


            modelBuilder.Entity<Language>(entity =>
            {
                entity.ToTable("Language");

                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });



            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
