using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebdevProjectStarterTemplate.Pages
{
    public class OberPaginaModel : PageModel
	{
		public string Username { get; set; }

		public void OnGet()
		{
			//Username = HttpContext.Session.GetString("username");
		}

	}
}
