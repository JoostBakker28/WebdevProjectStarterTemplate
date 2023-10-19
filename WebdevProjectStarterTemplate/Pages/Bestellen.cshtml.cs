using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class BestellenModel : PageModel
    {

        public IEnumerable<Table> Tables { get { return new TableRepository().Get(); } }//Haal alle tafels op
        public IEnumerable<Category> Categories { get { return new CategoryRepository().GetCategoriesWithProducts(); } }

        public IActionResult OnPost(string TableID)
        {
            HttpContext.Session.SetString("TableID", TableID);
            return RedirectToPage("/Bestellen");
        }
        public void OnGet()
        {
        }
    }
}
