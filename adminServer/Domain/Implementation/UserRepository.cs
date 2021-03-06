﻿using adminServer.Domain.Entities;
using adminServer.Domain.Interfaces;
using adminServer.Domain.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace adminServer.Domain.Implementation
{
    public class Repository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public Repository(ApplicationContext context)
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

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            var userEntities = await _context.Users.ToListAsync();
            return userEntities;
        }

        public async Task Update(UserEntity model)
        {
            await _context.SaveChangesAsync();
        }
    }
}
