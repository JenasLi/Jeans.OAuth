﻿using Jeans.OAuth.Core.Domains;
using Jeans.OAuth.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeans.OAuth.Server
{
    public class UserServer : IUserServer
    {
        private readonly IRepository<UserEntity> _userRepository;
        public UserServer(IRepository<UserEntity> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserEntity> GetUsers()
        {
            return _userRepository.Table.OrderBy(by => by.UserName).ToList();
        }

        public UserEntity GetUser(string userName, string password)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            try
            {
                return _userRepository.Table.SingleOrDefault(w => w.UserName == userName && w.Password == password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeleteUser(Guid id)
        {
            UserEntity entity = _userRepository.GetById(id);
            if (entity != null)
            {
                _userRepository.Delete(entity);
                return true;
            }

            return false;
        }

        public void AddUser(UserEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _userRepository.Insert(entity);
        }

        public void UpdateUser(UserEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            UserEntity userEntity = _userRepository.GetById(entity.Id);
            if (userEntity != null)
            {
                _userRepository.Update(userEntity);
            }
        }
    }
}
