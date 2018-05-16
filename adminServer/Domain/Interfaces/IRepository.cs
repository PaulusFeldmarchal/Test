using adminServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Interfaces
{
    internal interface IRepository
    {
        IList<UserEntity> GetAll();
        Task<UserEntity> Get(int id);
        void Update(UserEntity model);
        Task AddAsync(UserEntity model);
        Task Delete(UserEntity model);
    }
}
