using Cheshire_Waffles.Models;
using Cheshire_Waffles.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// This class represents the code-behind for the Checkout page.
public class CheckoutModel : PageModel
{
    private readonly IPurchaseService _purchaseService;
    private readonly ICartService _cartService;

    // Constructor to inject MenuService dependency.
    public CheckoutModel(ICartService cartService, IPurchaseService purchaseService)
    {
        _purchaseService = purchaseService;
        _cartService = cartService;
    }

    public IList<CartItem> CartItems
    {
        get
        {
            return _cartService.GetItems();
        }
    }

    public decimal Total
    {
        get
        {
            return _cartService.CalculateTotal();
        }
    }

    public IActionResult OnPostPurchase()
    {
        _purchaseService.ProcessPurchase();

        return RedirectToPage("Confirmation");
    }
}
