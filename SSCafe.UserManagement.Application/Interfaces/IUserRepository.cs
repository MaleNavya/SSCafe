
using System.Collections.Generic;
using SSCafe.UserManagement.Domain.Entities;

namespace SSCafe.UserManagement.Application.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();

        User? GetById(int id);

        User? GetByEmail(string email);

        void Add(User user);

        void Update(User user);

        void Delete(int id);
    }
}
