using System.Data;
using System.Data.SqlClient;

namespace Definer.Core.Repository.Connection
{
    public class DbConnection
    {
        private static string connectionString { get; set; }
        public DbConnection()
        {
            connectionString = "Server=MYSTIC;Database=Definer;User Id=sa;Password=123456;";
        }
        public static IDbConnection GetConnection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }
    }
}
