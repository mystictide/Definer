using System.Data;
using System.Data.SqlClient;

namespace Definer.Core.Repository.Connection
{
    public class DbConnection
    {
        private static string connectionString { get; set; }
        public DbConnection()
        {
            connectionString = "Server=ServerName;Database=DBName;User Id=ID;Password=Password;";
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
