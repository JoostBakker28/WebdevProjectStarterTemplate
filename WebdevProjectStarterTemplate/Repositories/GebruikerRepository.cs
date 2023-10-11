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

        public Gebruiker Get(string mail, string wachtwoord)
        {
            if (mail != null && wachtwoord != null)
            {
                string sql = "SELECT * From Gebruikers \r\nwhere Email = @mail AND Wachtwoord = @wachtwoord;";

                using var connection = GetConnection();
                var gebruiker = connection.QuerySingle<Gebruiker>(sql, new { mail, wachtwoord });
                return gebruiker;
            }
            else
            {
                return new Gebruiker();
            }
        }


    }
}
