using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class PersonaDto
    {
        public int Id { get; set; }

        public int IdPersona { get; set; }

        public string Nombre { get; set; } = null!;

        public int DateReg { get; set; }

        public int IdTipoPersona { get; set; }

        public int IdCategoriaPer { get; set; }

        public int IdCiudad { get; set; }
    }
}