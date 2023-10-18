using System.ComponentModel.DataAnnotations;

namespace WebdevProjectStarterTemplate.Models
{
    public class Gebruiker
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string wachtwoord { get; set; }
    }
}
