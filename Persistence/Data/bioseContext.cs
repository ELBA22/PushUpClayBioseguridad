using System;
using System.Collections.Generic;
using System.Reflection;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Data;

public partial class bioseContext : DbContext
{
 /*    public bioseContext()
    {
    } */

    public bioseContext(DbContextOptions<bioseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoriapersona> Categoriapersonas { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Contactopersona> Contactopersonas { get; set; }

    public virtual DbSet<Contrato> Contratos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Direccionpersona> Direccionpersonas { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Pais> Pais { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Programacion> Programacions { get; set; }

    public virtual DbSet<Tipocontacto> Tipocontactos { get; set; }

    public virtual DbSet<Tipodireccion> Tipodireccions { get; set; }

    public virtual DbSet<Tipopersona> Tipopersonas { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
       
    }

}
