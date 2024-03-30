using Cheshire_Waffles.Models;
using Cheshire_Waffles.Service.Abstraction;
using Microsoft.AspNetCore.Mvc.RazorPages;

// This class represents the code-behind for the Index page.
public class IndexModel : PageModel
{
    // Service to handle menu operations.
    private readonly IMenuService _menuService;

    // Constructor to inject MenuService dependency.
    public IndexModel(IMenuService menuService)
    {
        _menuService = menuService;
    }

    // Property to hold the list of menu items.
    public List<MenuItem> MenuItems { get; set; }

    // Handler method for HTTP GET requests.
    public void OnGet()
    {
        // Retrieve all menu items and assign them to the property.
        MenuItems = _menuService.GetMenuItems();
    }
}
