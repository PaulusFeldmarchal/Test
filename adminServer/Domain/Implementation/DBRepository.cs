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
        private readonly ApplicationContext _context;

        DBRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserEntity model)
        {
            await _context.Users.AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserEntity model)
        {
            _context.Users.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task<UserEntity> GetAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public IList<UserEntity> GetAll()
        {
            return _context.Users.ToList();
        }

        public void Update(UserEntity model)
        {
            _context.Users.Update(model);
        }
    }
}
