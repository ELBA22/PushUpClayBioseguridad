using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositorys
{
    public class CategoriaPersonaRepository :GenericRepository<Categoriapersona>, ICategoriapersona
    {
        private readonly bioseContext _context;

        public CategoriaPersonaRepository(bioseContext context): base (context)
        {
            _context = context;
        }

        
        
    }
}