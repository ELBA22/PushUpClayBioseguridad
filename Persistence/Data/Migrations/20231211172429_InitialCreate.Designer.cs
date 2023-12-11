﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(bioseContext))]
    [Migration("20231211172429_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Categoriapersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreCategoria")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombreCategoria");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("categoriapersona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCategoriaPer")
                        .HasColumnType("int");

                    b.Property<int>("IdDepartamento")
                        .HasColumnType("int");

                    b.Property<string>("NombreCiudad")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombreCiudad");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdDepartamento" }, "ciudad_iddepartamento_foreign");

                    b.HasIndex(new[] { "IdCategoriaPer" }, "persona_idcategoriaper_foreign");

                    b.ToTable("ciudad", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Contactopersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descripcion");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoContacto")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Descripcion" }, "contactopersona_descripcion_unique")
                        .IsUnique();

                    b.HasIndex(new[] { "IdPersona" }, "contactopersona_idpersona_foreign");

                    b.HasIndex(new[] { "IdTipoContacto" }, "contactopersona_idtipocontacto_foreign");

                    b.ToTable("contactopersona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateOnly>("FechaContrato")
                        .HasColumnType("date")
                        .HasColumnName("fechaContrato");

                    b.Property<DateOnly>("Fechafin")
                        .HasColumnType("date")
                        .HasColumnName("fechafin");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCliente" }, "contrato_idcliente_foreign");

                    b.HasIndex(new[] { "IdEmpleado" }, "contrato_idempleado_foreign");

                    b.HasIndex(new[] { "IdEstado" }, "contrato_idestado_foreign");

                    b.ToTable("contrato", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdPais")
                        .HasColumnType("int");

                    b.Property<string>("NombreDep")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombreDep");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPais" }, "departamento_idpais_foreign");

                    b.ToTable("departamento", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Direccionpersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Direccion")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("direccion");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoDireccion")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdPersona" }, "direccionpersona_idpersona_foreign");

                    b.HasIndex(new[] { "IdTipoDireccion" }, "direccionpersona_idtipodireccion_foreign");

                    b.ToTable("direccionpersona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("estado", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombrePais")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombrePais");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("pais", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("DateReg")
                        .HasColumnType("int")
                        .HasColumnName("dateReg");

                    b.Property<int>("IdCategoriaPer")
                        .HasColumnType("int");

                    b.Property<int>("IdCiudad")
                        .HasColumnType("int");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdTipoPersona")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdCiudad" }, "persona_idciudad_foreign");

                    b.HasIndex(new[] { "IdPersona" }, "persona_idpersona_unique")
                        .IsUnique();

                    b.HasIndex(new[] { "IdTipoPersona" }, "persona_idtipopersona_foreign");

                    b.ToTable("persona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdContrato")
                        .HasColumnType("int");

                    b.Property<int>("IdEmpleado")
                        .HasColumnType("int");

                    b.Property<int>("IdTurno")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "IdContrato" }, "programacion_idcontrato_foreign");

                    b.HasIndex(new[] { "IdEmpleado" }, "programacion_idempleado_foreign");

                    b.HasIndex(new[] { "IdTurno" }, "programacion_idturno_foreign");

                    b.ToTable("programacion", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime");

                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime");

                    b.Property<string>("Token")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("IdUserFk");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tipocontacto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipocontacto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tipodireccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipodireccion", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Tipopersona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("descripcion");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("tipopersona", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<TimeOnly>("HoraturnoF")
                        .HasColumnType("time")
                        .HasColumnName("horaturnoF");

                    b.Property<TimeOnly>("HoraturnoT")
                        .HasColumnType("time")
                        .HasColumnName("horaturnoT");

                    b.Property<string>("NombreTurno")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombreTurno");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("turnos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(225)
                        .HasColumnType("varchar(225)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<int>("IdUserFk")
                        .HasColumnType("int");

                    b.Property<int>("IdRolFk")
                        .HasColumnType("int");

                    b.HasKey("IdUserFk", "IdRolFk");

                    b.HasIndex("IdRolFk");

                    b.ToTable("userrol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.HasOne("Domain.Entities.Categoriapersona", "IdCategoriaPerNavigation")
                        .WithMany("Ciudads")
                        .HasForeignKey("IdCategoriaPer")
                        .IsRequired()
                        .HasConstraintName("persona_idcategoriaper_foreign");

                    b.HasOne("Domain.Entities.Departamento", "IdDepartamentoNavigation")
                        .WithMany("Ciudads")
                        .HasForeignKey("IdDepartamento")
                        .IsRequired()
                        .HasConstraintName("ciudad_iddepartamento_foreign");

                    b.Navigation("IdCategoriaPerNavigation");

                    b.Navigation("IdDepartamentoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Contactopersona", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "IdPersonaNavigation")
                        .WithMany("Contactopersonas")
                        .HasForeignKey("IdPersona")
                        .IsRequired()
                        .HasConstraintName("contactopersona_idpersona_foreign");

                    b.HasOne("Domain.Entities.Tipocontacto", "IdTipoContactoNavigation")
                        .WithMany("Contactopersonas")
                        .HasForeignKey("IdTipoContacto")
                        .IsRequired()
                        .HasConstraintName("contactopersona_idtipocontacto_foreign");

                    b.Navigation("IdPersonaNavigation");

                    b.Navigation("IdTipoContactoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "IdClienteNavigation")
                        .WithMany("ContratoIdClienteNavigations")
                        .HasForeignKey("IdCliente")
                        .IsRequired()
                        .HasConstraintName("contrato_idcliente_foreign");

                    b.HasOne("Domain.Entities.Persona", "IdEmpleadoNavigation")
                        .WithMany("ContratoIdEmpleadoNavigations")
                        .HasForeignKey("IdEmpleado")
                        .IsRequired()
                        .HasConstraintName("contrato_idempleado_foreign");

                    b.HasOne("Domain.Entities.Estado", "IdEstadoNavigation")
                        .WithMany("Contratos")
                        .HasForeignKey("IdEstado")
                        .IsRequired()
                        .HasConstraintName("contrato_idestado_foreign");

                    b.Navigation("IdClienteNavigation");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdEstadoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.HasOne("Domain.Entities.Pais", "IdPaisNavigation")
                        .WithMany("Departamentos")
                        .HasForeignKey("IdPais")
                        .IsRequired()
                        .HasConstraintName("departamento_idpais_foreign");

                    b.Navigation("IdPaisNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Direccionpersona", b =>
                {
                    b.HasOne("Domain.Entities.Persona", "IdPersonaNavigation")
                        .WithMany("Direccionpersonas")
                        .HasForeignKey("IdPersona")
                        .IsRequired()
                        .HasConstraintName("direccionpersona_idpersona_foreign");

                    b.HasOne("Domain.Entities.Tipodireccion", "IdTipoDireccionNavigation")
                        .WithMany("Direccionpersonas")
                        .HasForeignKey("IdTipoDireccion")
                        .IsRequired()
                        .HasConstraintName("direccionpersona_idtipodireccion_foreign");

                    b.Navigation("IdPersonaNavigation");

                    b.Navigation("IdTipoDireccionNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.HasOne("Domain.Entities.Ciudad", "IdCiudadNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdCiudad")
                        .IsRequired()
                        .HasConstraintName("persona_idciudad_foreign");

                    b.HasOne("Domain.Entities.Tipopersona", "IdTipoPersonaNavigation")
                        .WithMany("Personas")
                        .HasForeignKey("IdTipoPersona")
                        .IsRequired()
                        .HasConstraintName("persona_idtipopersona_foreign");

                    b.Navigation("IdCiudadNavigation");

                    b.Navigation("IdTipoPersonaNavigation");
                });

            modelBuilder.Entity("Domain.Entities.Programacion", b =>
                {
                    b.HasOne("Domain.Entities.Contrato", "IdContratoNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("IdContrato")
                        .IsRequired()
                        .HasConstraintName("programacion_idcontrato_foreign");

                    b.HasOne("Domain.Entities.Persona", "IdEmpleadoNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("IdEmpleado")
                        .IsRequired()
                        .HasConstraintName("programacion_idempleado_foreign");

                    b.HasOne("Domain.Entities.Turno", "IdTurnoNavigation")
                        .WithMany("Programacions")
                        .HasForeignKey("IdTurno")
                        .IsRequired()
                        .HasConstraintName("programacion_idturno_foreign");

                    b.Navigation("IdContratoNavigation");

                    b.Navigation("IdEmpleadoNavigation");

                    b.Navigation("IdTurnoNavigation");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "Users")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rols")
                        .WithMany("UserRols")
                        .HasForeignKey("IdRolFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "Users")
                        .WithMany("UserRols")
                        .HasForeignKey("IdUserFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rols");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Entities.Categoriapersona", b =>
                {
                    b.Navigation("Ciudads");
                });

            modelBuilder.Entity("Domain.Entities.Ciudad", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Contrato", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Domain.Entities.Departamento", b =>
                {
                    b.Navigation("Ciudads");
                });

            modelBuilder.Entity("Domain.Entities.Estado", b =>
                {
                    b.Navigation("Contratos");
                });

            modelBuilder.Entity("Domain.Entities.Pais", b =>
                {
                    b.Navigation("Departamentos");
                });

            modelBuilder.Entity("Domain.Entities.Persona", b =>
                {
                    b.Navigation("Contactopersonas");

                    b.Navigation("ContratoIdClienteNavigations");

                    b.Navigation("ContratoIdEmpleadoNavigations");

                    b.Navigation("Direccionpersonas");

                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("UserRols");
                });

            modelBuilder.Entity("Domain.Entities.Tipocontacto", b =>
                {
                    b.Navigation("Contactopersonas");
                });

            modelBuilder.Entity("Domain.Entities.Tipodireccion", b =>
                {
                    b.Navigation("Direccionpersonas");
                });

            modelBuilder.Entity("Domain.Entities.Tipopersona", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("Domain.Entities.Turno", b =>
                {
                    b.Navigation("Programacions");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UserRols");
                });
#pragma warning restore 612, 618
        }
    }
}
