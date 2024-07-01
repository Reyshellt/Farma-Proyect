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
    public class UsuarioDAO
    {
        private SqlConnection GetConnection()
        {
            return ConnectionToSql.Instance.GetConnection();
        }

        public DataTable BuscarUsuarios(string nombreUsuario)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC BuscarUsuarioPorNombreParcial @nombreUsuario", connection);
                command.Parameters.AddWithValue("@nombreUsuario", "%" + nombreUsuario + "%");

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public void InsertarUsuario(string nombre, string apellido, DateTime fechaNacimiento, string nombreUsuario, string clave, string tipoUsuario)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC InsertarUsuario @nombre, @apellido, @fechaNacimiento, @nombreUsuario, @clave, @tipoUsuario", connection);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                command.Parameters.AddWithValue("@clave", clave);
                command.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);

                command.ExecuteNonQuery();
            }
        }

        public void ModificarUsuario(int idUsuario, string nombre, string apellido, DateTime fechaNacimiento, string nombreUsuario, string clave, string tipoUsuario)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC ActualizarUsuario @idUsuario, @nombre, @apellido, @fechaNacimiento, @nombreUsuario, @clave, @tipoUsuario", connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.Parameters.AddWithValue("@fechaNacimiento", fechaNacimiento);
                command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);
                command.Parameters.AddWithValue("@clave", clave);
                command.Parameters.AddWithValue("@tipoUsuario", tipoUsuario);

                command.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC EliminarUsuario @idUsuario", connection);
                command.Parameters.AddWithValue("@idUsuario", idUsuario);

                command.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerTodosLosUsuarios()
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC SeleccionarUsuarios", connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("EXEC BuscarUsuarioPorNombre @nombreUsuario", connection);
                command.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        UsuarioID = reader.GetInt32(reader.GetOrdinal("UsuarioID")),
                        Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                        Apellido = reader.GetString(reader.GetOrdinal("Apellido")),
                        FechaNacimiento = reader.GetDateTime(reader.GetOrdinal("FechaNacimiento")),
                        TipoUsuario = reader.GetString(reader.GetOrdinal("TipoUsuario")),
                        Username = reader.GetString(reader.GetOrdinal("Username")),
                        Clave = reader.GetString(reader.GetOrdinal("Clave"))
                    };

                    return usuario;
                }
                else
                {
                    return null; // Usuario no encontrado
                }
            }
        }

    }
}
