using Microsoft.EntityFrameworkCore;
using SSCafe.UserManagement.Domain.Entities;
using SSCafe.UserManagement.Domain.Interfaces;
using SSCafe.UserManagement.Infrastructure.Data;

namespace SSCafe.UserManagement.Infrastructure.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppDbContext _context;

        public MenuRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Menu>> GetAllMenus()
        {
            return await _context.Menus.ToListAsync();
        }

        public async Task<Menu?> GetMenuById(int id)
        {
            return await _context.Menus.FindAsync(id);
        }

        public async Task<Menu> AddMenu(Menu menu)
        {
            _context.Menus.Add(menu);

            await _context.SaveChangesAsync();

            return menu;
        }

        public async Task<Menu?> UpdateMenu(int id, Menu updatedMenu)
        {
            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
                return null;

            menu.Name = updatedMenu.Name;
            menu.Description = updatedMenu.Description;
            menu.Price = updatedMenu.Price;
            menu.ImageUrl = updatedMenu.ImageUrl;
           

            await _context.SaveChangesAsync();

            return menu;
        }

        public async Task<bool> DeleteMenu(int id)
        {
            var menu = await _context.Menus.FindAsync(id);

            if (menu == null)
                return false;

            _context.Menus.Remove(menu);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}