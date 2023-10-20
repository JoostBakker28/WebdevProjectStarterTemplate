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
            string sql = "Select * From webdevproject.Tafels";

            using var connection = GetConnection();
            var tafels = connection.Query<Table>(sql);
            return tafels;
        }
    }
}
