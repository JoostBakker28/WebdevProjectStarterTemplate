using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Tls;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using WebdevProjectStarterTemplate.Models;

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

        public IActionResult OnPostLogIn(string mail, string wachtwoord)
        {
        Gebruiker gebruiker = new Repositories.GebruikerRepository().Get(mail, wachtwoord);
            if(gebruiker.mail != null && gebruiker.wachtwoord != null)
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
        public IActionResult OnPostTafels()
        {
        return RedirectToPage("/TafelSelectie");
        }
    }
