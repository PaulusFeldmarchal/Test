using adminServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<IList<UserModel>> GetAll();
        Task<UserModel> Get(int id);
        Task Update(UserModel model);
        Task Add(UserModel model);
        Task Delete(int id);
    }
}
