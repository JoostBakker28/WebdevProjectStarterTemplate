using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class AllesbetalenModel : PageModel
    {
        public IEnumerable<Table> TableList { get { return new TableRepository().Get(); } }//Haal alle tafels op en zet ze in een lijst
        public IEnumerable<Category> Categories { get { return new CategoryRepository().GetCategoriesWithProducts(); } }
        public IEnumerable<Order> Orders
        {
            get
            {
                string result;
                result = Regex.Match(SelectedTableID, @"\d+").Value;
                return new OrderRepository().Get(Int32.Parse(result));
            }
        }

        [BindProperty(SupportsGet = true)]
        public string SelectedTableID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; } = null!;

        public double TotaalBedrag { get; set; }


        public IActionResult OnGet(string table)
        {
            if (this.SelectedTableID != null)
            {
                Response.Cookies.Append("SelectedTable", table);
                return Page();
            }
            else if (table == null && Request.Cookies["SelectedTable"] != null)
            {
                this.SelectedTableID = Request.Cookies["SelectedTable"];
                return RedirectToPage("/AllesBetalen", new { table = this.SelectedTableID });
            }
            else
            {
                return Page();
            }
        }

        public void OnPostBetalen(int TableID)
        {
            new OrderRepository().AllesBetalen(TableID);
        }
        public void OnPostAdd(int TableID, int ProductID, int Amount)
        {
            new OrderRepository().AddToOrder(TableID, ProductID, Amount);
        }
        public void OnPostRemove1(int TableID, int ProductID, int Amount)
        {
            new OrderRepository().RemoveOneFromOrder(TableID, ProductID, Amount);
        }
        public void OnPostRemoveAll(int TableID, int ProductID, int Amount)
        {
            new OrderRepository().RemoveFromOrder(TableID, ProductID);
        }
    }
}
