using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("ciudad");

            builder.HasIndex(e => e.IdDepartamento, "ciudad_iddepartamento_foreign");

            builder.HasIndex(e => e.IdCategoriaPer, "persona_idcategoriaper_foreign");

            builder.Property(e => e.NombreCiudad)
                .HasMaxLength(255)
                .HasColumnName("nombreCiudad");

            builder.HasOne(d => d.IdCategoriaPerNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdCategoriaPer)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("persona_idcategoriaper_foreign");

            builder.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.IdDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ciudad_iddepartamento_foreign");
        }
    }
}