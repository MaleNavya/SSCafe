
using Microsoft.EntityFrameworkCore;
using SSCafe.UserManagement.Application.Interfaces;
using SSCafe.UserManagement.Domain.Entities;
using SSCafe.UserManagement.Infrastructure.Data;

namespace SSCafe.UserManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(
                u => u.Email == email);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(
                u => u.Id == id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
