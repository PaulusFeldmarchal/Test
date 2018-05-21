using frontendServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frontendServer.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> GetAsync(int id);
        Task Update(UserEntity model);
        Task AddAsync(UserEntity model);
        Task DeleteAsync(UserEntity model);
        Task DeleteAllAsync();
    }
}
