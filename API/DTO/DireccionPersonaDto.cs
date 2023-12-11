using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.DTO
{
    public class DireccionPersonaDto
    {
        public int Id { get; set; }

        public string Direccion { get; set; } = null!;

        public int IdPersona { get; set; }

        public int IdTipoDireccion { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;

        public virtual Tipodireccion IdTipoDireccionNavigation { get; set; } = null!;
    }
}