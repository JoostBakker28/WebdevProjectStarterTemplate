using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebdevProjectStarterTemplate.Models;
using WebdevProjectStarterTemplate.Repositories;

namespace WebdevProjectStarterTemplate.Pages
{
    public class RegistrerenModel : PageModel
    {

        public string ErrorMessage { get; set; }


        public void OnGet()
        {
        }

        public void OnPostRegistreren(string Email, string wachtwoord, string wachtwoord2, int verificatiecode)
        {
            if(wachtwoord == wachtwoord2)
            {
                if(verificatiecode == 12345678)
                {
                    new UserRepository().AddUser(Email, wachtwoord);
                    ErrorMessage = "Registreren Succesvol";
                }
                else
                {
                    ErrorMessage = "verificatiecode is onjuist";
                }
            }
            else
            {
                ErrorMessage = "wachtwoorden komen niet overeen";
            };
        }
    }
}
