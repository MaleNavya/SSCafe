using System;
using System.Collections.Generic;
using System.Text;

using SSCafe.UserManagement.Domain.Entities;

namespace SSCafe.UserManagement.Application.Interfaces
{
    public interface IUserRoleRepository
    {
        IEnumerable<UserRole> GetAll();

        UserRole GetById(int id);

        void Add(UserRole userRole);

        void Update(UserRole userRole);

        void Delete(int id);
    }
}