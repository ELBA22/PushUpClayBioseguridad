using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class TurnoDto
    {
        public int Id { get; set; }

        public string NombreTurno { get; set; } = null!;

        public TimeOnly HoraturnoT { get; set; }

        public TimeOnly HoraturnoF { get; set; }
    }
}