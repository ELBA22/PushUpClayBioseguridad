using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class EstadoDto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}