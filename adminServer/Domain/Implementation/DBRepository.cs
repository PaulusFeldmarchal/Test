using adminServer.Domain.Entities;
using adminServer.Domain.Interfaces;
using adminServer.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Implementation
{
    public class DBRepository : IRepository
    {
        private readonly Persistence.AppContext _context;

        DBRepository(Persistence.AppContext context)
        {
            _context = context;
        }

        public Task Add(UserEntity model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserEntity>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(UserEntity model)
        {
            throw new NotImplementedException();
        }
    }
}
