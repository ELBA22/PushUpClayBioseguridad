using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.DTO
{
    public class ContactoPersonaDto
    {
        public int Id { get; set; }

        public string Descripcion { get; set; } = null!;

        public int IdPersona { get; set; }

        public int IdTipoContacto { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; } = null!;

        public virtual Tipocontacto IdTipoContactoNavigation { get; set; } = null!;
    }
}