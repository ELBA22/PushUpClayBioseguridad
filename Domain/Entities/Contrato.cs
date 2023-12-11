using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contrato
{
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public DateOnly FechaContrato { get; set; }

    public int IdEmpleado { get; set; }

    public DateOnly Fechafin { get; set; }

    public int IdEstado { get; set; }

    public virtual Persona IdClienteNavigation { get; set; } = null!;

    public virtual Persona IdEmpleadoNavigation { get; set; } = null!;

    public virtual Estado IdEstadoNavigation { get; set; } = null!;

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
