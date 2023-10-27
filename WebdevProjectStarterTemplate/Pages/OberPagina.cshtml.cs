using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Pages
{
    public class OberPaginaModel : PageModel
    {
        public string Username { get; set; }
        public User user = null;

        public IActionResult OnGet(string table) //Checkt of er daadwerkelijk is ingelogd, voordat de oberpagina wordt geopend
        {
            try { user = JsonSerializer.Deserialize<User>(HttpContext.Session.Get("User")); }
            catch { user = null; }

            if (user == null) //als je niet ingelogd bent wordt je terug gestuurd naar het inlog scherm
            {
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }

        }
    }
}
