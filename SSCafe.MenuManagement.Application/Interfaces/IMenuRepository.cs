using SSCafe.UserManagement.Domain.Entities;

namespace SSCafe.UserManagement.Domain.Interfaces
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenus();

        Task<Menu?> GetMenuById(int id);

        Task<Menu> AddMenu(Menu menu);

        Task<Menu?> UpdateMenu(int id, Menu menu);

        Task<bool> DeleteMenu(int id);
    }
}