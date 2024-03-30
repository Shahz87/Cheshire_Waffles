using Cheshire_Waffles.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ContactModel : PageModel
{
    private readonly IEmailService _emailService;

    public ContactModel(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [BindProperty]
    public string Name { get; set; }

    [BindProperty]
    public string Email { get; set; }

    [BindProperty]
    public string Message { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Compose the email message
        var subject = "New Contact Form Submission";
        var body = $"Name: {Name}\nEmail: {Email}\nMessage: {Message}";

        // Send the email
        _emailService.SendEmail("support@TCR.com", subject, body);

        // Redirect to a thank you page or show a success message
        return RedirectToPage("ThankYou");
    }
}
