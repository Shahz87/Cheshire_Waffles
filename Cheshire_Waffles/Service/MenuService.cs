using Cheshire_Waffles.Models;
using Cheshire_Waffles.Repository.Abstraction;
using Cheshire_Waffles.Service.Abstraction;

namespace Cheshire_Waffles.Service
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public List<MenuItem> GetMenuItems()
        {
            return _menuRepository.GetMenuItems();
        }

        public MenuItem GetMenuItemById(int id)
        {
            return _menuRepository.GetMenuItemById(id);
        }

        public void AddMenuItem(MenuItem newItem)
        {
            _menuRepository.AddMenuItem(newItem);
        }

        public void EditMenuItem(MenuItem editedItem)
        {
            _menuRepository.EditMenuItem(editedItem);
        }

        public void DeleteMenuItem(int id)
        {
            _menuRepository.DeleteMenuItem(id);
        }
    }

}
