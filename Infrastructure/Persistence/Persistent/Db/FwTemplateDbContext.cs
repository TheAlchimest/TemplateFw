using Microsoft.EntityFrameworkCore;
using TemplateFw.Domain.Models;
using TemplateFw.Persistence.Persistent.Db.Configures;
using TemplateFw.Domain.Models.Announces;
using TemplateFw.Persistence.Persistent.Db.Configurations;
using TemplateFw.Domain.Models.Countries;

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

        public virtual DbSet<Faq> Faqs { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<Portal> Portals { get; set; }
        public virtual DbSet<VwFaqFullData> VwFaqFullData { get; set; }
        public virtual DbSet<VwPortalFullData> VwPortalDetails { get; set; }
        public virtual DbSet<Announce> Announces { get; set; }
        public virtual DbSet<AnnounceDetail> AnnounceDetails { get; set; }
        public virtual DbSet<VwAnnounceDetail> VwAnnounceDetail { get; set; }
        public virtual DbSet<VwAnnounceFullData> VwAnnounceFullData { get; set; }
        public virtual DbSet<AnnounceUser> AnnounceUsers { get; set; }


        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<ActionLog> ActionLogs { get; set; }

        public virtual DbSet<SourceUIApplication> SourceUIApplications { get; set; }


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

            modelBuilder.Entity<Portal>(entity =>
            {
                entity.ToTable("Portal");

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(250);
                entity.Property(e => e.DescriptionAr)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.NameAr)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DescriptionEn)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.NameEn)
                    .IsRequired()
                    .HasMaxLength(50);

            });

           



            modelBuilder.Entity<VwPortalFullData>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("VwPortalDetail");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Link)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            

            modelBuilder.Entity<ActionLog>(entity =>
            {
                entity.HasKey(a => a.Id);
            });

            modelBuilder.Entity<SourceUIApplication>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(300);
            });

            // Faq Configuration
            modelBuilder.ApplyConfiguration(new FaqConfiguration());
            modelBuilder.ApplyConfiguration(new VwFaqFullDetailConfiguration());

            modelBuilder.ApplyConfiguration(new AnnounceConfiguration());
            modelBuilder.ApplyConfiguration(new AnnounceDetailConfiguration());
            modelBuilder.ApplyConfiguration(new VwAnnounceDetailConfiguration());
            modelBuilder.ApplyConfiguration(new VwAnnounceFullDetailConfiguration());
            modelBuilder.ApplyConfiguration(new AnnounceUserConfiguration());

            modelBuilder.ApplyConfiguration(new CountryConfiguration());

            OnModelCreatingPartial(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
