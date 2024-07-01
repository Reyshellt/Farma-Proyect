using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_AD
{
    public class DataAccess
    {
        private readonly ConnectionToSql connectionToSql;

        public DataAccess()
        {
            connectionToSql = ConnectionToSql.Instance;
        }

        public DataTable ExecuteQuery(string query, SqlParameter parameter)
        {
            using (SqlConnection connection = connectionToSql.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (SqlConnection connection = connectionToSql.GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
