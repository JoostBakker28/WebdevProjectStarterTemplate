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

        public IActionResult OnPost()
        {
        if(SelectedTableID != null)
            HttpContext.Session.SetString("TableID", Convert.ToString(SelectedTableID));
            GekozenTafelMessage = "Geselecteerde tafel: Tafel " + SelectedTableID;
            return Page(); 
        }
        public string table { get; set; }

        public void OnGet()
        {
        }
    }
}
