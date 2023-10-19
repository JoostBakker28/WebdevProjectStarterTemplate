using System.Data;
using Dapper;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class TableRepository
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }

        public IEnumerable<Table>Get()
        {
            string sql = "Select * From Tafels";

            using var connection = GetConnection();
            var order = connection.Query<Table>(sql);
            return order;
        }
    }
}
