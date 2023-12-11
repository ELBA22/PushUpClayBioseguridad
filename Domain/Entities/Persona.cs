using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persona
{
    public int Id { get; set; }

    public int IdPersona { get; set; }

    public string Nombre { get; set; } = null!;

    public int DateReg { get; set; }

    public int IdTipoPersona { get; set; }

    public int IdCategoriaPer { get; set; }

    public int IdCiudad { get; set; }

    public virtual ICollection<Contactopersona> Contactopersonas { get; set; } = new List<Contactopersona>();

    public virtual ICollection<Contrato> ContratoIdClienteNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Contrato> ContratoIdEmpleadoNavigations { get; set; } = new List<Contrato>();

    public virtual ICollection<Direccionpersona> Direccionpersonas { get; set; } = new List<Direccionpersona>();

    public virtual Ciudad IdCiudadNavigation { get; set; } = null!;

    public virtual Tipopersona IdTipoPersonaNavigation { get; set; } = null!;

    public virtual ICollection<Programacion> Programacions { get; set; } = new List<Programacion>();
}
