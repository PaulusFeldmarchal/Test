using adminServer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Interfaces
{
    internal interface IRepository : IDisposable 
    {
        Task<IList<UserEntity>> GetAll();
        Task<UserEntity> Get(int id);
        Task Update(UserEntity model);
        Task Add(UserEntity model);
        Task Delete(int id);
    }
}
