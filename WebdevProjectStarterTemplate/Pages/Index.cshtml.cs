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
        Gebruiker gebruiker = new Repositories.GebruikerRepository().Get(Email, wachtwoord);
            if(gebruiker.Email != null && gebruiker.wachtwoord != null)
            {
            HttpContext.Session.SetString("Gebruiker", JsonSerializer.Serialize(gebruiker));
                return RedirectToPage("/OberPagina");
            }
            else
            {
                ErrorMessage = "Email of wachtwoord is onjuist";
                return Page();
            }
        }
        public void OnPostTafels(Object sender, EventArgs e)
        {
        Response.Redirect("/TafelSelectie");
        }
        
    }
