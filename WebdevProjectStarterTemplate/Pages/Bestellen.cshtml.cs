using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
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
        public IEnumerable<Order> Orders { get
            {
                string result;
                result = Regex.Match(Convert.ToString(SelectedTableID), @"/d+").Value;
                return new OrderRepository().Get(Int32.Parse(result));
            } }

        [BindProperty]
        public string SelectedTableID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; } = null!;

        public IActionResult OnPost()
        {
            if (SelectedTableID != null)
            {
                HttpContext.Session.SetString("TableID", SelectedTableID);
                Response.Cookies.Append("SelectedTable", SelectedTableID);
            }
            return Page(); 
        }

        public IActionResult OnGet() 
        {
            if(this.SelectedTableID != null)
            {
                Response.Cookies.Append("SelectedTable", SelectedTableID);
                return Page();

            }
            else if(this.SelectedTableID == null && Request.Cookies["SelectedTable"] != null)
            {
                this.SelectedTableID = Request.Cookies["SelectedTable"];
                return RedirectToPage("/Bestellen", new {SelectedTableID });
            }
            else
            {
                return Page();
            }
        }

    }
}
