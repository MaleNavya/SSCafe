using SSCafe.UserManagement.Domain.Entities;
using SSCafe.UserManagement.Domain.Interfaces;
using SSCafe.UserManagement.Application.DTOs;

namespace SSCafe.UserManagement.Application.Services
{
    public class MenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public async Task<List<MenuDto>> GetAllMenus()
        {
            var menus = await _menuRepository.GetAllMenus();

            return menus.Select(m => new MenuDto
            {
                Id = m.Id,
                Name = m.Name,
                Description = m.Description ?? string.Empty,
                Price = m.Price,
                ImageUrl = m.ImageUrl ?? string.Empty,
                
            }).ToList();
        }

        public async Task<MenuDto?> GetMenuById(int id)
        {
            var menu = await _menuRepository.GetMenuById(id);

            if (menu == null)
                return null;

            return new MenuDto
            {
                Id = menu.Id,
                Name = menu.Name,
                Description = menu.Description ?? string.Empty,
                Price = menu.Price,
                ImageUrl = menu.ImageUrl ?? string.Empty,
             
            };
        }

        public async Task<MenuDto> AddMenu(MenuDto menuDto)
        {
            var menu = new Menu
            {
                Name = menuDto.Name,
                Description = menuDto.Description,
                Price = menuDto.Price,
                ImageUrl = menuDto.ImageUrl,
                
            };

            var result = await _menuRepository.AddMenu(menu);

            return new MenuDto
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description ?? string.Empty,
                Price = result.Price,
                ImageUrl = result.ImageUrl ?? string.Empty,
               
            };
        }

        public async Task<MenuDto?> UpdateMenu(int id, MenuDto menuDto)
        {
            var menu = new Menu
            {
                Name = menuDto.Name,
                Description = menuDto.Description,
                Price = menuDto.Price,
                ImageUrl = menuDto.ImageUrl,
                
            };

            var updatedMenu = await _menuRepository.UpdateMenu(id, menu);

            if (updatedMenu == null)
                return null;

            return new MenuDto
            {
                Id = updatedMenu.Id,
                Name = updatedMenu.Name,
                Description = updatedMenu.Description ?? string.Empty,
                Price = updatedMenu.Price,
                ImageUrl = updatedMenu.ImageUrl ?? string.Empty,
             
            };
        }

        public async Task<bool> DeleteMenu(int id)
        {
            return await _menuRepository.DeleteMenu(id);
        }
    }
}