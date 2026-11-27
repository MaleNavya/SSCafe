using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using SSCafe.UserManagement.Application.DTOs;
using SSCafe.UserManagement.Application.Interfaces;
using SSCafe.UserManagement.Domain.Entities;

namespace SSCafe.UserManagement.Application.Services
{
    public class RoleService
    {
        private readonly IRoleRepository _repository;

        public RoleService(IRoleRepository repository)
            => _repository = repository;

        public IEnumerable<RoleDto> GetAllRoles() =>
            _repository.GetAll().Select(r => new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            });

        public RoleDto GetRoleById(int id)
        {
            var r = _repository.GetById(id);

            return r == null ? null : new RoleDto
            {
                Id = r.Id,
                Name = r.Name
            };
        }

        public void AddRole(RoleDto dto)
        {
            var role = new Role
            {
                Name = dto.Name
            };

            _repository.Add(role);
        }

        public void UpdateRole(int id, RoleDto dto)
        {
            var role = _repository.GetById(id);

            if (role == null) return;

            role.Name = dto.Name;

            _repository.Update(role);
        }

        public void DeleteRole(int id) =>
            _repository.Delete(id);
    }
}