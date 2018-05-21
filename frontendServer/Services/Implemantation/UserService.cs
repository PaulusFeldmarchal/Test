using frontendServer.Domain.Interfaces;
using frontendServer.Domain.Entities;
using frontendServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using frontendServer.Services.Interfaces;

namespace frontendServer.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(UserModel model)
        {
            var entity = new UserEntity
            {
                Name = model.FirstName + ' ' + model.LastName,
                Age = model.Age
            };
            await _repository.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _repository.GetAsync(id);
            if (entity == null)
                return;
            await _repository.DeleteAsync(entity);
        }

        public async Task DeleteAll()
        {
            await _repository.DeleteAllAsync();
        }

        public async Task<UserModel> Get(int id)
        {
            var entity = await _repository.GetAsync(id);
            string[] names = entity.Name.Split(' ');

            var model = new UserModel
            {
                Id = entity.Id,
                FirstName = names[0],
                LastName = names[1],
                Age = entity.Age
            };

            return model;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var entities = await _repository.GetAll();
            var result = entities.Select(entity => new UserModel {
                Id = entity.Id,
                FirstName = entity.Name.Split(' ')[0],
                LastName = entity.Name.Split(' ')[1],
                Age = entity.Age
            });


            return result;
        }

        public async Task Update(UserModel model)
        {
            var entity = await _repository.GetAsync(model.Id);
            entity.Name = model.FirstName + ' ' + model.LastName;
            entity.Age = model.Age;

            await _repository.Update(entity);

        }
    }
}
