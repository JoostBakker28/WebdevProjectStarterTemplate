using Dapper;
using System.Data;
using WebdevProjectStarterTemplate.Models;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class OrderRepository
    {
    private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }
        
        public IEnumerable<Order> Get(int TableID)
        {
            string sql = "SELECT * FROM tableOrder WHERE TableID = @TableID ORDER BY TableID ASC";

            using var connection = GetConnection();
            var order = connection.Query<Order>(sql, new { TableID });
            return order;
        }


    }

}
