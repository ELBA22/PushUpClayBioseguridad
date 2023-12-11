using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositorys
{
    public class ContratoRepository : GenericRepository<Contrato>, IContrato
    {
        private readonly bioseContext _context;
        public ContratoRepository(bioseContext context) : base(context)
        {
            _context = context;
        }

        public static implicit operator ContratoRepository(DepartamentoRepository v)
        {
            throw new NotImplementedException();
        }
    }
}