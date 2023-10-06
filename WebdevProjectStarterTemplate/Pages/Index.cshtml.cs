using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Crypto.Tls;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;

namespace WebdevProjectStarterTemplate.Pages;

public class IndexModel : PageModel
{
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Wachtwoord { get; set; }

        public IActionResult OnPost(string email, string wachtwoord)
        {
            if (Email == "Joost@test.nl" && Wachtwoord == "1234")
            {
                //HttpContext.Session.SetString("Email", Email);
                return RedirectToPage("/OberPagina");
            }
            else
            {
                return Page();
            }
        }

        public void OnGet()
        {

        }
        public void LogIn()
        {

        }
    }
