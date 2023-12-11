using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Tipodireccion
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Direccionpersona> Direccionpersonas { get; set; } = new List<Direccionpersona>();
}
