using Cheshire_Waffles.Infrastructure;
using Cheshire_Waffles.Models;
using Cheshire_Waffles.Repository.Abstraction;

namespace Cheshire_Waffles.Repository
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly RestaurantDbContext _dbContext;

        public PurchaseRepository(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateOrder(Order order)
        {
            _dbContext.Orders.Add(order);
            _dbContext.SaveChanges();
        }
    }
}
