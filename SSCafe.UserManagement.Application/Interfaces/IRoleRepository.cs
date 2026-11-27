using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

using SSCafe.UserManagement.Domain.Entities;

namespace SSCafe.UserManagement.Application.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();

        Role GetById(int id);

        void Add(Role role);

        void Update(Role role);

        void Delete(int id);
    }
}
