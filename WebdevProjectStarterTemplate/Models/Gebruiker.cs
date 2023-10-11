using System.ComponentModel.DataAnnotations;

namespace WebdevProjectStarterTemplate.Models
{
    public class Gebruiker
    {
        [Required]
        public string mail { get; set; }
        [Required]
        public string wachtwoord { get; set; }
    }
}
