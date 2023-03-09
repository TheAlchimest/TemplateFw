﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TemplateFw.Domain.Models.Countries;

namespace TemplateFw.Persistence.Persistent.Db.Configurations
{
    internal class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> entity)
        {
            entity.ToTable("Country");

            entity.HasKey(a => a.Id);

            entity.Property(e => e.ArName)
                 .HasMaxLength(120)
                .HasDefaultValueSql("(N'')");

            entity.Property(e => e.EnName)
               .HasMaxLength(120);
        }
    }
}

