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

        public async Task Add(UserModel model)
        {
            await _repository.AddAsync(new UserEntity
            {
                Name = model.FirstName + ' ' + model.LastName,
                Age = model.Age
            });
        }

        public async Task Delete(UserModel model)
        {
            UserEntity entity = new UserEntity
            {
                Id = model.Id,
                Name = model.FirstName + ' ' + model.LastName,
                Age = model.Age
            };
            await _repository.DeleteAsync(entity);
        }

        public async Task<UserModel> Get(int id)
        {
            UserEntity entity = await _repository.GetAsync(id);
            string[] names = entity.Name.Split(' ');
            return new UserModel
            {
                Id = entity.Id,
                FirstName = names[0],
                LastName = names[1],
                Age = entity.Age
            };
        }

        public IList<UserModel> GetAll()
        {
            IList<UserModel> result = new List<UserModel>();
            IList<UserEntity> entities = _repository.GetAll();

            foreach(UserEntity entity in entities)
            {
                string[] names = entity.Name.Split(' ');
                result.Add(new UserModel
                {
                    Id = entity.Id,
                    FirstName = names[0],
                    LastName = names[1],
                    Age = entity.Age
                });
            }

            return result;
        }

        public void Update(UserModel model)
        {
            _repository.Update(new UserEntity
            {
                Id = model.Id,
                Name = model.FirstName + ' ' + model.LastName,
                Age = model.Age
            });
        }
    }
}
