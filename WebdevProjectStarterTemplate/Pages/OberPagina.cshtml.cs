using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class OberPaginaModel : PageModel
    {
        public IEnumerable<Table> TableList { get { return new TableRepository().Get(); } }//Haal alle tafels op en zet ze in een lijst
        public IEnumerable<Order> OrdersList
        {
            get
            {
                string result;
                result = Regex.Match(SelectedTableID, @"\d+").Value;
                return new OrderRepository().Get(Int32.Parse(result));
            }
        }
        public IEnumerable<Order> AllOrders { get { return new OrderRepository().GetAllOrders(); } }


        [BindProperty(SupportsGet = true)]
        public string SelectedTableID { get; set; }

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
                return RedirectToPage("/OberPagina", new { table = this.SelectedTableID });
            }
            else
            {
                return Page();
            }
        }
    }
}

