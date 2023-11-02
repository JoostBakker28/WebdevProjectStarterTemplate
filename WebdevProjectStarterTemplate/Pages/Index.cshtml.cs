using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages;

public class IndexModel : PageModel
{
        [BindProperty]
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
        public string ErrorMessage { get; set; }

        private readonly ILogger<IndexModel> _logger;
        public void OnGet()
        {

        }

        public IndexModel(ILogger<IndexModel> logger)
        {
         _logger = logger;
        }

        public IActionResult OnPostLogIn(string Email, string wachtwoord)
        {
        User gebruiker = new UserRepository().Get(Email, wachtwoord); //Check of de login klopt
            if(gebruiker.Email != null && gebruiker.wachtwoord != null) //check of alles is ingevuld
            {
            HttpContext.Session.SetString("User", JsonSerializer.Serialize(gebruiker));//Set User
            
                return RedirectToPage("/OberPagina");
            }
            else
            {
                ErrorMessage = "Email of wachtwoord niet ingevuld";
                return Page();
            }
        }
        public void OnPostBestellen(Object sender, EventArgs e)
        {
        Response.Redirect("/Bestellen");
        }

        public void OnPostRegistreren(Object sender, EventArgs e)
        {
        Response.Redirect("/Registreren");
        }

}
