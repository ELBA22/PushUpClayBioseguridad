using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.DTO
{
    public class CiudadDto
    {
        public int Id { get; set; }

        public string NombreCiudad { get; set; } = null!;

        public int IdDepartamento { get; set; }

        public int IdCategoriaPer { get; set; }

        public virtual Categoriapersona IdCategoriaPerNavigation { get; set; } = null!;

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
    }
}