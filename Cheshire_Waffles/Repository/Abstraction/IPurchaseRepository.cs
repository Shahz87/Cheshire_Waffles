using Cheshire_Waffles.Models;

namespace Cheshire_Waffles.Repository.Abstraction
{
    public interface IPurchaseRepository
    {
        void CreateOrder(Order order);
    }
}