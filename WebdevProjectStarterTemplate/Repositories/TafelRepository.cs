using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class TafelRepository
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }

        public IEnumerable<Tafel>Get()
        {
            string sql = "Select * From Tafels";

            using var connection = GetConnection();
            var order = connection.Query<Tafel>(sql);
            return order;
        }
    }
}
