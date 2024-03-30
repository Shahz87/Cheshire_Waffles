using Cheshire_Waffles.Models;

namespace Cheshire_Waffles.Repository.Abstraction
{
    public interface IMenuRepository
    {
        List<MenuItem> GetMenuItems();
        MenuItem GetMenuItemById(int id);
        void AddMenuItem(MenuItem newItem);
        void EditMenuItem(MenuItem editedItem);
        void DeleteMenuItem(int id);
    }
}
