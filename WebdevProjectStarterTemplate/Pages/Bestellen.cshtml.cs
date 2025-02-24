using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySqlX.XDevAPI.Relational;
using System.Text.RegularExpressions;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class BestellenModel : PageModel
    {

        public IEnumerable<Models.Table> TableList { get { return new TableRepository().Get(); } }//Haal alle tafels op en zet ze in een lijst
        public IEnumerable<Category> Categories { get { return new CategoryRepository().GetCategoriesWithProducts(); } } 
        public IEnumerable<Order> OrdersList { get
            {
                string? result;
                if (SelectedTableID != "0")
                {
                    result = SelectedTableID;
                }
                else if (Request.Cookies["SelectedTable"] != null)
                {
                    result = Request.Cookies["SelectedTable"];
                }
                else
                {
                    result = "0";
                }
                return new OrderRepository().Get(Int32.Parse(result));
            } }

        [BindProperty(SupportsGet = true)]
        public string SelectedTableID { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Category { get; set; } = null!;


        public IActionResult OnGet(string table) //Selected Table instellen en in de cookie zetten
        {
            if (this.SelectedTableID != null)
            {
                Response.Cookies.Append("SelectedTable", table);
                return Page();
            }
            else if (table == null && Request.Cookies["SelectedTable"] != null)
            {
                this.SelectedTableID = Request.Cookies["SelectedTable"];
                return RedirectToPage("/Bestellen", new { table = this.SelectedTableID });
            }
            else
            {
                return Page();
            }
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
