using Dapper;
using Org.BouncyCastle.Asn1.Cmp;
using System.Data;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class GebruikerRepository
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }

        public Gebruiker Get(string Email, string wachtwoord)
        {
            if (Email != null && wachtwoord != null)
            {
                string sql = "SELECT * From webdevproject.Gebruikers \r\nwhere Email = @Email AND Wachtwoord = @wachtwoord;";

                using var connection = GetConnection();
                var gebruiker = connection.QuerySingle<Gebruiker>(sql, new { Email, wachtwoord });
                return gebruiker;
            }
            else
            {
                return new Gebruiker();
            }
        }


    }
}
