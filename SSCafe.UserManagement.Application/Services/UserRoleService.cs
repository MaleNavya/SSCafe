using System;
using System.Collections.Generic;
using System.Text;

using SSCafe.UserManagement.Domain.Entities;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Interfaces;

namespace SSCafe.UserManagement.Application.Services
{
    public class UserRoleService
    {
        private readonly IUserRoleRepository _repository;

        public UserRoleService(IUserRoleRepository repository)
            => _repository = repository;

        public IEnumerable<UserRoleDto> GetAllUserRoles() =>
            _repository.GetAll().Select(ur => new UserRoleDto
            {
                Id = ur.Id,
                UserId = ur.UserId,
                RoleId = ur.RoleId
            });

        public UserRoleDto GetUserRoleById(int id)
        {
            var ur = _repository.GetById(id);

            return ur == null ? null : new UserRoleDto
            {
                Id = ur.Id,
                UserId = ur.UserId,
                RoleId = ur.RoleId
            };
        }

        public void AddUserRole(UserRoleDto dto)
        {
            var userRole = new UserRole
            {
                UserId = dto.UserId,
                RoleId = dto.RoleId
            };

            _repository.Add(userRole);
        }

        public void UpdateUserRole(int id, UserRoleDto dto)
        {
            var userRole = _repository.GetById(id);

            if (userRole == null) return;

            userRole.UserId = dto.UserId;
            userRole.RoleId = dto.RoleId;

            _repository.Update(userRole);
        }

        public void DeleteUserRole(int id) =>
            _repository.Delete(id);
    }
}