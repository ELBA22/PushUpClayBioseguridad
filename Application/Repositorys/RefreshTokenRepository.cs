using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Persistence.Data;

namespace Application.Repositorys
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>
    {
        private readonly bioseContext _context;
        public RefreshTokenRepository(bioseContext context) : base(context)
        {
            _context = context;
        }
    }
}