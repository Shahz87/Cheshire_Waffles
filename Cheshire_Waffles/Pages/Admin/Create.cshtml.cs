using Cheshire_Waffles.Models;
using Cheshire_Waffles.Repository.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cheshire_Waffles.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IMenuRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public IFormFile Image { get; set; }
        [BindProperty]
        public MenuItem MenuItem { get; set; }

        public CreateModel(IWebHostEnvironment webHostEnvironment, IMenuRepository repository)
        {
            _repository = repository;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> OnPost()
        {
            if (Image != null && Image.Length > 0)
            {
                var basepath = Path.Combine(_webHostEnvironment.WebRootPath, "images/menu");
                if (!Directory.Exists(basepath)) Directory.CreateDirectory(basepath);

                string uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;

                var imagePath = Path.Combine(basepath, uniqueFileName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                MenuItem.ImageUrl = uniqueFileName;
            }

            _repository.AddMenuItem(MenuItem);

            TempData["Notification"] = "Item Created successfully.";
            return RedirectToPage("./Admin");
        }
    }
}
