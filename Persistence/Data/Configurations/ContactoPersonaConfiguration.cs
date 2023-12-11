using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ContactoPersonaConfiguration : IEntityTypeConfiguration<Contactopersona>
    {
        public void Configure(EntityTypeBuilder<Contactopersona> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contactopersona");

            builder.HasIndex(e => e.Descripcion, "contactopersona_descripcion_unique").IsUnique();

            builder.HasIndex(e => e.IdPersona, "contactopersona_idpersona_foreign");

            builder.HasIndex(e => e.IdTipoContacto, "contactopersona_idtipocontacto_foreign");

            builder.Property(e => e.Descripcion).HasColumnName("descripcion");

            builder.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdPersona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactopersona_idpersona_foreign");

            builder.HasOne(d => d.IdTipoContactoNavigation).WithMany(p => p.Contactopersonas)
                .HasForeignKey(d => d.IdTipoContacto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contactopersona_idtipocontacto_foreign");
        }
    }
}