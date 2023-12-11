using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Ciudad
{
    public int Id { get; set; }

    public string NombreCiudad { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public int IdCategoriaPer { get; set; }

    public virtual Categoriapersona IdCategoriaPerNavigation { get; set; } = null!;

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();
}
