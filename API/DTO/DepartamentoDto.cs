using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.DTO
{
    public class DepartamentoDto
    {
        public int Id { get; set; }

        public string NombreDep { get; set; } = null!;

        public int IdPais { get; set; }
        public virtual Pais IdPaisNavigation { get; set; } = null!;
    }
}