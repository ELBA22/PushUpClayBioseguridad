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
    public class TurnoConfiguration : IEntityTypeConfiguration<Turno>
    {
        public void Configure(EntityTypeBuilder<Turno> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("turnos");

            builder.Property(e => e.HoraturnoF)
                 .HasColumnType("time")
                 .HasColumnName("horaturnoF");
            builder.Property(e => e.HoraturnoT)
                 .HasColumnType("time")
                 .HasColumnName("horaturnoT");
            builder.Property(e => e.NombreTurno)
                .HasMaxLength(255)
                .HasColumnName("nombreTurno");
        }
    }
}