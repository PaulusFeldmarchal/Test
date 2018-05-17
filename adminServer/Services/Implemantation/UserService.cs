﻿using adminServer.Domain.Interfaces;
using adminServer.Domain.Entities;
using adminServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using adminServer.Services.Interfaces;

namespace adminServer.Services.Implementation
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
            await _repository.AddAsync(new UserEntity
            {
                Name = model.FirstName + ' ' + model.LastName,
                Age = model.Age
            });
        }

        public async Task Delete(int id)
        {
            UserEntity entity = await _repository.GetAsync(id);
            if (entity == null)
                return;
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

        public async Task<IList<UserModel>> GetAll()
        {
            IList<UserModel> result = new List<UserModel>();
            IList<UserEntity> entities = await _repository.GetAll();

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

        public async Task Update(UserModel model)
        {
            await _repository.Update(new UserEntity
            {
                Id = model.Id,
                Name = model.FirstName + ' ' + model.LastName,
                Age = model.Age
            });
        }
    }
}
