using Cheshire_Waffles.Models;
using Cheshire_Waffles.Repository.Abstraction;
using Cheshire_Waffles.Service.Abstraction;

namespace Cheshire_Waffles.Service
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ICartService _cartService;

        public PurchaseService(ICartService cartService, IPurchaseRepository purchaseRepository)
        {
            _purchaseRepository = purchaseRepository;
            _cartService = cartService;
        }

        public void ProcessPurchase()
        {
            Order order = new Order
            {
                UserId = "1",
                Total = _cartService.CalculateTotal(),
                OrderItems = new List<OrderItem>()
            };

            foreach (var item in _cartService.GetItems())
            {
                order.OrderItems.Add(new OrderItem
                {
                    Name = item.Name,
                    Price = item.Price,
                    Quantity = item.Quantity,
                });
            }

            _purchaseRepository.CreateOrder(order);
        }
    }
}
