using System;
using System.Collections.Generic;
using System.Text;

using SSCafe.UserManagement.Domain.Entities;
using SSCafe.UserManagement.Application.Interfaces;
using SSCafe.UserManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SSCafe.UserManagement.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly AppDbContext _context;

        public UserRoleRepository(AppDbContext context) => _context = context;

        public IEnumerable<UserRole> GetAll() =>
            _context.UserRoles.ToList();

        public UserRole GetById(int id) =>
            _context.UserRoles.FirstOrDefault(ur => ur.Id == id);

        public void Add(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
        }

        public void Update(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userRole = _context.UserRoles
                .FirstOrDefault(ur => ur.Id == id);

            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();
            }
        }
    }
}