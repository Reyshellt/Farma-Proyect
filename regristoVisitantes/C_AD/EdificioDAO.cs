using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_AD
{
    public class EdificioDAO
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
                string query = "EXEC BuscarEdificioPorNombreParcial @Nombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void Insertar(string nombre)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC InsertarEdificio @Nombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.ExecuteNonQuery();
            }
        }

        public void Modificar(int idEdificio, string nombre)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC ActualizarNombreEdificio  @IdEdificio, @Nombre";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@IdEdificio", idEdificio);
                command.ExecuteNonQuery();
            }
        }

        public void Eliminar(int idEdificio)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC EliminarEdificio @IdEdificio";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEdificio", idEdificio);
                command.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodos()
        {
            using(SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC SeleccionarEdificios";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public string ObtenerNombreEdificioPorId(int idEdificio)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "EXEC SeleccionarNombreEdificioPorID @IdEdificio";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IdEdificio", idEdificio);
                object result = command.ExecuteScalar();
                return result != null ? result.ToString() : string.Empty;
            }
        }


            public List<DateTime> ObtenerFechasEntradaEdificios()
            {
                List<DateTime> fechasEntrada = new List<DateTime>();

                using (SqlConnection connection = GetConnection())
                {
                    string query = "EXEC SeleccionarHoraEntradaVisitas";

                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        DateTime fechaEntrada = Convert.ToDateTime(reader["HoraEntrada"]);
                        fechasEntrada.Add(fechaEntrada);
                    }

                    reader.Close();
                }

                return fechasEntrada;
            }

    }
}
