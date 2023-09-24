using System.Data.SqlClient;

namespace Production_Analysis.DbServices
{
    /// <summary>
    /// Database connection to MS SQL Server
    /// </summary>
    public class DbConnection
    {
        private readonly string connectionString;

        public DbConnection()
        {
            connectionString = "Server=(local); DataBase=ProductionAnalysis; Integrated Security=true";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
