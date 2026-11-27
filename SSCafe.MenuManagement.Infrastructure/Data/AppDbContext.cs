using Microsoft.EntityFrameworkCore;
using SSCafe.UserManagement.Domain.Entities;

namespace SSCafe.UserManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Menu> Menus => Set<Menu>();
    }
}