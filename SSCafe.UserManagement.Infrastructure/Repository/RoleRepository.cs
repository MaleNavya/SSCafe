using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SSCafe.UserManagement.Application.Interfaces;
using SSCafe.UserManagement.Domain.Entities;
using SSCafe.UserManagement.Infrastructure.Data;

namespace SSCafe.UserManagement.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context) => _context = context;

        public IEnumerable<Role> GetAll() =>
            _context.Roles.ToList();

        public Role GetById(int id) =>
            _context.Roles.FirstOrDefault(r => r.Id == id);

        public void Add(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void Update(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);

            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}
