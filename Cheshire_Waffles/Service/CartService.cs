using System.Text.Json;
using Cheshire_Waffles.Models;

public class CartService : ICartService
{
    private List<CartItem> Items = new List<CartItem>();
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
        IList<CartItem> _items = GetCartItemsFromSession();
        if (_items is not null && _items.Count > 0)
        {
            Items.AddRange(_items);
        }
    }
    private IList<CartItem> GetCartItemsFromSession()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartItemsJson = session.GetString("CartItems");
        return cartItemsJson != null ? JsonSerializer.Deserialize<IList<CartItem>>(cartItemsJson) : new List<CartItem>();
    }

    private void SaveCartItemsToSession()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        var cartItemsJson = JsonSerializer.Serialize(Items);
        session.SetString("CartItems", cartItemsJson);
    }
    public void AddItem(CartItem item)
    {
        var existingItem = Items.FirstOrDefault(i => i.Id == item.Id);
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            Items.Add(item);
        }
        SaveCartItemsToSession();
    }

    public IList<CartItem> GetItems()
    {
        return Items;
    }


    public void RemoveItem(int itemId)
    {
        var itemToRemove = Items.FirstOrDefault(i => i.Id == itemId);
        if (itemToRemove != null)
        {
            Items.Remove(itemToRemove);
            SaveCartItemsToSession();
        }
    }

    public decimal CalculateTotal()
    {
        return Items.Sum(item => item.Price * item.Quantity);
    }
}
