using Cheshire_Waffles.Models;
using Cheshire_Waffles.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cheshire_Waffles.Pages.Admin
{
    public class DetailsModel : PageModel
    {
        private readonly IMenuRepository _repository;

        public DetailsModel(IMenuRepository repository)
        {
            _repository = repository;
        }

        public MenuItem MenuItem { get; set; }

        public IActionResult OnGet(int id)
        {
            MenuItem = _repository.GetMenuItemById(id);
            if (MenuItem == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
