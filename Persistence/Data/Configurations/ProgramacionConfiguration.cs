using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations
{
    public class ProgramacionConfiguration : IEntityTypeConfiguration<Programacion>
    {
        public void Configure(EntityTypeBuilder<Programacion> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("programacion");

            builder.HasIndex(e => e.IdContrato, "programacion_idcontrato_foreign");

            builder.HasIndex(e => e.IdEmpleado, "programacion_idempleado_foreign");

            builder.HasIndex(e => e.IdTurno, "programacion_idturno_foreign");

            builder.HasOne(d => d.IdContratoNavigation).WithMany(p => p.Programacions)
                   .HasForeignKey(d => d.IdContrato)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("programacion_idcontrato_foreign");

            builder.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Programacions)
                 .HasForeignKey(d => d.IdEmpleado)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("programacion_idempleado_foreign");

            builder.HasOne(d => d.IdTurnoNavigation).WithMany(p => p.Programacions)
                 .HasForeignKey(d => d.IdTurno)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("programacion_idturno_foreign");
        }
    }
}