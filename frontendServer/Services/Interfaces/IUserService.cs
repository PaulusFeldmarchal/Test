using frontendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace frontendServer.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserModel> Get(int id);
        Task Update(UserModel model);
        Task Add(UserModel model);
        Task Delete(int id);
        Task DeleteAll();
    }
}
