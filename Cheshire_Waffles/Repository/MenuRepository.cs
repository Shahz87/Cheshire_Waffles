using Cheshire_Waffles.Infrastructure;
using Cheshire_Waffles.Models;
using Cheshire_Waffles.Repository.Abstraction;

namespace Cheshire_Waffles.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public MenuRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<MenuItem> GetMenuItems()
        {
            return _dbContext.MenuItems.ToList();
        }

        public MenuItem? GetMenuItemById(int id)
        {
            return _dbContext.MenuItems.Find(id);
        }

        public void AddMenuItem(MenuItem newItem)
        {
            _dbContext.MenuItems.Add(newItem);
            _dbContext.SaveChanges();
        }

        public void EditMenuItem(MenuItem editedItem)
        {
            _dbContext.MenuItems.Update(editedItem);
            _dbContext.SaveChanges();
        }

        public void DeleteMenuItem(int id)
        {
            var menuItem = _dbContext.MenuItems.Find(id);
            if (menuItem != null)
            {
                _dbContext.MenuItems.Remove(menuItem);
                _dbContext.SaveChanges();
            }
        }
    }
}
