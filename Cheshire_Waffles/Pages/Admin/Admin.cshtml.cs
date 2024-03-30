using Cheshire_Waffles.Models;
using Cheshire_Waffles.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cheshire_Waffles.Pages.Admin
{
    public class DashboardModel : PageModel
    {
        private readonly IMenuRepository _repository;

        public DashboardModel(IMenuRepository repository)
        {
            _repository = repository;
        }

        public List<MenuItem> MenuItems { get; private set; }

        public void OnGet()
        {
            MenuItems = _repository.GetMenuItems();
        }

        public IActionResult OnPostDelete(int id)
        {
            TempData["Notification"] = "Item Deleted successfully.";
            _repository.DeleteMenuItem(id);
            return RedirectToPage("./Admin");
        }
    }
}
