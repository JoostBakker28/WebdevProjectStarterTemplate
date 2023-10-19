using Dapper;
using Org.BouncyCastle.Asn1.Cmp;
using System.Data;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class UserRepository
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }

        public User Get(string Email, string wachtwoord)
        {
            if (Email != null && wachtwoord != null)
            {
                string sql = "SELECT * From webdevproject.Users \r\nwhere Email = @Email AND Wachtwoord = @wachtwoord;";

                using var connection = GetConnection();
                var gebruiker = connection.QuerySingle<User>(sql, new { Email, wachtwoord });
                return gebruiker;
            }
            else
            {
                return new User();
            }
        }


    }
}
