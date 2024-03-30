using Cheshire_Waffles.Models;

public interface ICartService
{
    void AddItem(CartItem item);
    IList<CartItem> GetItems();
    decimal CalculateTotal();
    void RemoveItem(int itemId);
}