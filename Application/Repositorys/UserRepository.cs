using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositorys
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        private readonly bioseContext _context;
        public UserRepository(bioseContext context) : base(context)
        {
            _context = context;
        }
    }
}