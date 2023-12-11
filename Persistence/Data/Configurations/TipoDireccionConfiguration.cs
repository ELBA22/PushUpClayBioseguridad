using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class TipoDireccionConfiguration : IEntityTypeConfiguration<Tipodireccion>
    {
        public void Configure(EntityTypeBuilder<Tipodireccion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("tipodireccion");

            builder.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        }
    }
}