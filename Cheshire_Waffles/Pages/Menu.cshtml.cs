using Cheshire_Waffles.Models;
using Cheshire_Waffles.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class MenuModel : PageModel
{
    private readonly IMenuService _menuService;
    private readonly ICartService _cartService;
    [BindProperty]
    public string searchQuery { get; set; } = string.Empty;

    public MenuModel(IMenuService menuService, ICartService cartService)
    {
        _menuService = menuService;
        _cartService = cartService;
    }

    public List<MenuItem> MenuItems { get; set; }

    public void OnGet(string search)
    {
        if (string.IsNullOrEmpty(search))
        {
            MenuItems = _menuService.GetMenuItems();
        }
        else
        {
            searchQuery = search;
            MenuItems = _menuService.GetMenuItems()
                .Where(item => item.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                               item.Description.Contains(search, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }

    public IActionResult OnPostOrder(int id)
    {
        MenuItem selectedItem = _menuService.GetMenuItemById(id);

        if (selectedItem == null)
        {
            return NotFound();
        }

        _cartService.AddItem(new CartItem { Id = selectedItem.Id, Name = selectedItem.Name, Quantity = 1, Price = selectedItem.Price });
        return RedirectToPage("/Checkout");
    }
}
