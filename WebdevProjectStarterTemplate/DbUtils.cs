using System.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace WebdevProjectStarterTemplate
{
    public class DbUtils
    {
        public DbUtils()
        {
        }
        
        public IDbConnection GetDbConnection()
        {
            string connectionString = Program.Configuration
                .GetConnectionString("WebdevCourseRazorPages.Exercises.MySQL")!;

            return new MySqlConnection(connectionString);
        }
    }
}
