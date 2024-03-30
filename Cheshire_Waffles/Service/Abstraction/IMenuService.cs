using Cheshire_Waffles.Models;

namespace Cheshire_Waffles.Service.Abstraction
{
    public interface IMenuService
    {
        void AddMenuItem(MenuItem newItem);
        void DeleteMenuItem(int id);
        void EditMenuItem(MenuItem editedItem);
        MenuItem GetMenuItemById(int id);
        List<MenuItem> GetMenuItems();
    }
}
