using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace C_AD
{
    public sealed class ConnectionToSql
    {
        private static readonly ConnectionToSql instance = new ConnectionToSql();
        private readonly string connectionString;

        // Private constructor to prevent instantiation
        private ConnectionToSql()
        {
            connectionString = "Server=REY\\SQLEXPRESS01;Database=InstitutoTecnologicoAmericas;Integrated Security=true";
        }

        // Public static method to access the singleton instance
        public static ConnectionToSql Instance
        {
            get { return instance; }
        }

        // Method to get a connection
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
