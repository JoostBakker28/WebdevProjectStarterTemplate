using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using System.Diagnostics.Eventing.Reader;

namespace WebdevProjectStarterTemplate.Pages.pagina
{
    public class InlogModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Wachtwoord { get; set; }

        public IActionResult OnPost()
        {
            if(Email == "Joost@test.nl" && Wachtwoord == "1234")
            {
				return new RedirectToPageResult("/Pagina/OberPagina");
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
}
