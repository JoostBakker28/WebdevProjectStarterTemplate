using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages
{
    public class BestellenModel : PageModel
    {

        public IActionResult OnPost(string tafel)
        {
            HttpContext.Session.SetString("TafelNummer", tafel);
            return RedirectToPage("/Bestellen");
        }
        public void OnGet()
        {
        }
    }
}