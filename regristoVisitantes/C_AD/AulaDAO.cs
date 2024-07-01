using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_Entidades;

namespace C_AD
{
    public class AulaDAO
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
                string query = "EXEC BuscarAulaPorNombreParcial @Nombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void Insertar(string nombre, int edificioID)
        {
            using (SqlConnection connection = GetConnection())
            {   

                connection.Open();
                string query = "EXEC InsertarAula @Nombre, @EdificioID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@EdificioID", edificioID);
                command.ExecuteNonQuery();
            }
        }

        public void Modificar(int idAula, string nombre, int edificioID)
        {
            using (SqlConnection connection = GetConnection())
            {

                connection.Open();
                string query = "EXEC ActualizarAula @IdAula, @Nombre, @EdificioID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@EdificioID", edificioID);
                command.Parameters.AddWithValue("@IdAula", idAula);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idAula)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC EliminarAula @IdAula";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAula", idAula);
                command.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodos()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC SeleccionarAulas";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable BuscarAulaPorId(int idAula)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC SeleccionarAulaPorID @IdAula";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdAula", idAula);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public DataTable ObtenerAulasPorEdificio (int edificioId) 
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC SeleccionarAulasPorEdificioID @EdificioID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EdificioID", edificioId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

    }
}
