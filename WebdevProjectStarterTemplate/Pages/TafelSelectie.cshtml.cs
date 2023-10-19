using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.RegularExpressions;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class TafelSelectieModel : PageModel {

        public IEnumerable<Table> Tafels { get { return new TableRepository().Get(); } }//Haal alle tafels op


    } 
}
