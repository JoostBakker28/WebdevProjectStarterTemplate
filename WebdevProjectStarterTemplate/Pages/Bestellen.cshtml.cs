using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Classes;

namespace WebdevProjectStarterTemplate.Pages
{
    public class BestellenModel : PageModel
    {
        public TafelNaam GetSelectedTafelNaam(MyModel model)
{
    return model.tafelnaam;
}
        public void OnGet()
        {
        }
    }
}
