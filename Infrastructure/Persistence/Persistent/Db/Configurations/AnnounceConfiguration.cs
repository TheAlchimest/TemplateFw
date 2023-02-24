
using TemplateFw.Domain.Models.Announces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TemplateFw.Persistence.Persistent.Db.Configures
{

    internal class AnnounceConfiguration : IEntityTypeConfiguration<Announce>
    {
        public void Configure(EntityTypeBuilder<Announce> entity)
        {
            entity.ToTable("Announces");

            entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

            entity.Property(e => e.LastModifiedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);


            entity.Property(e => e.LastActivationBy)
                  .HasMaxLength(30)
                  .IsUnicode(false);

            entity.Property(e => e.LastDectivationBy)
                    .HasMaxLength(30)
                    .IsUnicode(false);


        }
    }

    internal class AnnounceDetailConfiguration : IEntityTypeConfiguration<AnnounceDetail>
    {
        public void Configure(EntityTypeBuilder<AnnounceDetail> entity)
        {
            entity.ToTable("AnnounceDetails");

            entity.HasKey(e => new { e.AnnounceId, e.LanguageId });

            entity.HasIndex(e => e.LanguageId, "IX_AnnounceDetail_LanguageId");

            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(2000);

            entity.HasOne(d => d.Announce)
                .WithMany(p => p.AnnounceDetails)
                .HasForeignKey(d => d.AnnounceId);


        }
    }

    internal class AnnounceUserConfiguration : IEntityTypeConfiguration<AnnounceUser>
    {
        public void Configure(EntityTypeBuilder<AnnounceUser> entity)
        {
            entity.ToTable("AnnounceUsers");

            entity.HasKey(e => new { e.AnnounceId, e.UserId });
       
            entity.HasOne(d => d.Announce)
                .WithMany(p => p.AnnounceUsers)
                .HasForeignKey(d => d.AnnounceId);

        }
    }

    
    internal class VwAnnounceDetailConfiguration : IEntityTypeConfiguration<VwAnnounceDetail>
    {
        public void Configure(EntityTypeBuilder<VwAnnounceDetail> entity)
        {
            entity.HasNoKey();

            entity.ToView("VwAnnounceDetail");

            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(e => e.CreatedBy)
                            .IsRequired()
                            .HasMaxLength(30)
                            .IsUnicode(false);

            entity.Property(e => e.LastModifiedBy)
                            .HasMaxLength(30)
                            .IsUnicode(false);

        }
    }

    internal class VwAnnounceFullDetailConfiguration : IEntityTypeConfiguration<VwAnnounceFullData>
    {
        public void Configure(EntityTypeBuilder<VwAnnounceFullData> entity)
        {
            entity.HasNoKey();

            entity.ToView("VwAnnounceFullData");

            entity.Property(e => e.Content)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(e => e.CreatedBy)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.LanguageName)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(e => e.LastModifiedBy)
                .HasMaxLength(30)
                .IsUnicode(false);

        }
    }


}
