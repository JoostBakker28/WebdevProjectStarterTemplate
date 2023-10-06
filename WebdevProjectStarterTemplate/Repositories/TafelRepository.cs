using System.Data;

namespace WebdevProjectStarterTemplate.Repositories
{
    public class TafelRepository
    {
        private IDbConnection GetConnection()
        {
            return new DbUtils().GetDbConnection();
        }
    }
}
