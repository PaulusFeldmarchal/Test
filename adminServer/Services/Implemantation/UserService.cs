using adminServer.Domain.Interfaces;
using adminServer.Domain.Entities;
using adminServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminServer.Domain.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;

        UserService(IRepository repository)
        {
            _repository = repository;
        }

        public Task Add(UserModel model)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Update(UserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
