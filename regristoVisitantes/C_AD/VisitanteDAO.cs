using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_AD
{
    public class VisitanteDAO
    {
        
        private SqlConnection GetConnection()
        {
            return ConnectionToSql.Instance.GetConnection();
        }

        public DataTable BuscarPorNombre(string nombre)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC SeleccionarVisitantesPorNombre @Nombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void Insertar(string nombre, string apellido, string carrera)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC InsertarVisitante @Nombre, @Apellido, @Carrera";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Carrera", carrera);
                command.ExecuteNonQuery();
            }
        }

        public void Modificar(int idVisitante, string nombre, string apellido, string carrera)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC ActualizarVisitante @IdVisitante, @Nombre, @Apellido, @Carrera";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Carrera", carrera);
                command.Parameters.AddWithValue("@IdVisitante", idVisitante);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idVisitante)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC EliminarVisitante @IdVisitante";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdVisitante", idVisitante);
                command.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodos()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC SeleccionarTodosVisitantes";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}
