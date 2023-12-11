using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Direccionpersona
{
    public int Id { get; set; }

    public string Direccion { get; set; } = null!;

    public int IdPersona { get; set; }

    public int IdTipoDireccion { get; set; }

    public virtual Persona IdPersonaNavigation { get; set; } = null!;

    public virtual Tipodireccion IdTipoDireccionNavigation { get; set; } = null!;
}
