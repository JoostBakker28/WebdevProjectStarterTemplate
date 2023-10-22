using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class BestellenModel : PageModel
    {

        public IEnumerable<Table> TableList { get { return new TableRepository().Get(); } }//Haal alle tafels op en zet ze in een lijst
        public IEnumerable<Category> Categories { get { return new CategoryRepository().GetCategoriesWithProducts(); } }

        [BindProperty]
        public int SelectedTableID { get; set; }
        public string GekozenTafelMessage { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; } = null!;

        public IActionResult OnPost()
        {
        if(SelectedTableID != 0)
            HttpContext.Session.SetString("TableID", Convert.ToString(SelectedTableID));
            if (SelectedTableID != 0)
            {
                GekozenTafelMessage = "Geselecteerde tafel: Tafel " + SelectedTableID;
            }
            return Page(); 
        }
        public string table { get; set; }

        public IActionResult OnGet() //TODO: code fixen!
        {
            if(this.SelectedTableID != 0)
            {
                Response.Cookies.Append("SelectedTable", Convert.ToString(SelectedTableID));
                return Page();
            }
            else if(this.SelectedTableID == 0 && Request.Cookies["SelectedTable"] != null)
            {
                return RedirectToPage("/Bestellen", new { table = this.SelectedTableID });
            }
            else
            {
                return Page();
            }
        }
    }
}
