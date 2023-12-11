using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contactopersona
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdPersona { get; set; }

    public int IdTipoContacto { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual Tipocontacto IdTipoContactoNavigation { get; set; } = null!;
}
