using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Categoriapersona
{
    public int Id { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
}
