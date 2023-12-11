using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.DTO
{
    public class ProgramacionDto
    {
        public int Id { get; set; }

        public int IdContrato { get; set; }

        public int IdTurno { get; set; }

        public int IdEmpleado { get; set; }

        public virtual Contrato IdContratoNavigation { get; set; } = null!;

        public virtual Persona IdEmpleadoNavigation { get; set; } = null!;

        public virtual Turno IdTurnoNavigation { get; set; } = null!;
    }
}