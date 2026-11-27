using System;
using System.Collections.Generic;
using System.Text;

using SSCafe.UserManagement.Domain.Entities;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Interfaces;

namespace SSCafe.UserManagement.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
            => _repository = repository;

        public IEnumerable<UserDto> GetAllUsers() =>
            _repository.GetAll().Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password
            });

        public UserDto GetUserById(int id)
        {
            var u = _repository.GetById(id);

            return u == null ? null : new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Password = u.Password
            };
        }

        public void AddUser(UserDto dto)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };

            _repository.Add(user);
        }

        public void UpdateUser(int id, UserDto dto)
        {
            var user = _repository.GetById(id);

            if (user == null) return;

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Password = dto.Password;

            _repository.Update(user);
        }

        public void DeleteUser(int id) =>
            _repository.Delete(id);
    }
}