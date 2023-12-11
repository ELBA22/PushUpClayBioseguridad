using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class DireccionPersonaConfiguration : IEntityTypeConfiguration<Direccionpersona>
    {
        public void Configure(EntityTypeBuilder<Direccionpersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("direccionpersona");

            builder.HasIndex(e => e.IdPersona, "direccionpersona_idpersona_foreign");

            builder.HasIndex(e => e.IdTipoDireccion, "direccionpersona_idtipodireccion_foreign");

            builder.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");

            builder.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Direccionpersonas)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("direccionpersona_idpersona_foreign");

            builder.HasOne(d => d.IdTipoDireccionNavigation).WithMany(p => p.Direccionpersonas)
                .HasForeignKey(d => d.IdTipoDireccion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("direccionpersona_idtipodireccion_foreign");
        }
    }
}