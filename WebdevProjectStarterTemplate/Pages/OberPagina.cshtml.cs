using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
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

