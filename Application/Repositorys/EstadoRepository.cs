using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositorys
{
    public class EstadoRepository : GenericRepository<Estado>, IEstado
    {
        private readonly bioseContext _context;
        public EstadoRepository(bioseContext context) : base(context)
        {
            _context = context;
        }
    }
}