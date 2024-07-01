using C_Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_AD
{
    public class VisitaDAL
    {
        private SqlConnection GetConnection()
        {
            return ConnectionToSql.Instance.GetConnection();
        }

        public DataTable ObtenerTodasLasVisitas()
        {
            using (SqlConnection connection = GetConnection())
            {

                string query = "EXEC SeleccionarVisitas";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        public DataTable ObtenerInformacionVisitas()
        {
            using (SqlConnection connection = GetConnection())
            {

                string query = "EXEC ObtenerInformacionVisitas";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                    return dataTable;
                }
            }
        }

        public void InsertarVisita(Visita visita)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "EXEC InsertarVisita @UsuarioID ,@VisitanteID ,@EdificioID ,@AulaID, @HoraEntrada ,@HoraSalida ,@MotivoVisita ";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", visita.UsuarioID);
                    command.Parameters.AddWithValue("@VisitanteID", visita.VisitanteID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@EdificioID", visita.EdificioID);
                    command.Parameters.AddWithValue("@AulaID", visita.AulaID);
                    command.Parameters.AddWithValue("@HoraEntrada", visita.HoraEntrada);
                    command.Parameters.AddWithValue("@HoraSalida", visita.HoraSalida ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MotivoVisita", visita.MotivoVisita ?? (object)DBNull.Value);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void ModificarVisita(Visita visita)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "EXEC ActualizarVisita @VisitaID, @UsuarioID, @VisitanteID, @EdificioID, @AulaID, @HoraEntrada, @HoraSalida, @MotivoVisita";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UsuarioID", visita.UsuarioID);
                    command.Parameters.AddWithValue("@VisitanteID", visita.VisitanteID ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@EdificioID", visita.EdificioID);
                    command.Parameters.AddWithValue("@AulaID", visita.AulaID);
                    command.Parameters.AddWithValue("@HoraEntrada", visita.HoraEntrada);
                    command.Parameters.AddWithValue("@HoraSalida", visita.HoraSalida ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@MotivoVisita", visita.MotivoVisita ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@VisitaID", visita.VisitaID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarVisita(int visitaID)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "EXEC EliminarVisita @VisitaID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VisitaID", visitaID);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


        public DataTable ObtenerVisitasPorIdVisitante(int idVisitante)
        {
            DataTable dataTable = new DataTable();
            string query = "EXEC SeleccionarVisitasPorVisitanteID @VisitanteID";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VisitanteID", idVisitante);
                    connection.Open();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            return dataTable;
        }

        public int ObtenerCantidadVisitantesPorEdificio(int edificioId)
        {
            int cantidad = 0;

            using (SqlConnection connection = GetConnection())
            {
                string query = "EXEC ContarVisitasPorEdificioID @EdificioID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EdificioID", edificioId);

                    try
                    {
                        connection.Open();
                        cantidad = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener la cantidad de visitantes por edificio: " + ex.Message);
                    }
                }
            }

            return cantidad;
        }

        public Visita ObtenerVisitaPorID(int idVisita)
        {
            Visita visita = null;
            string query = "EXEC SeleccionarVisitaPorID @VisitaID";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@VisitaID", idVisita);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            visita = new Visita
                            {
                                // Aquí asigna los valores de las columnas del lector al objeto Visita
                                VisitaID = (int)reader["VisitaID"],
                                UsuarioID = (int)reader["UsuarioID"],
                                VisitanteID = (int)reader["VisitanteID"],
                                EdificioID = (int)reader["EdificioID"],
                                AulaID = (int)reader["AulaID"],
                                HoraEntrada = (DateTime)reader["HoraEntrada"],
                                HoraSalida = reader["HoraSalida"] != DBNull.Value ? (DateTime)reader["HoraSalida"] : (DateTime?)null,
                                MotivoVisita = (string)reader["MotivoVisita"]
                            };
                        }
                    }
                }
            }

            return visita;
        }



        public int ObtenerCantidadVisitantesPorEdificioYFecha(int edificioId, DateTime fecha)
        {
            int cantidad = 0;

            using (SqlConnection connection = GetConnection())
            {
                string query = "EXEC ContarVisitasPorEdificioYFecha @EdificioID, @Fecha";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@EdificioID", edificioId);
                    command.Parameters.AddWithValue("@Fecha", fecha.Date);

                    try
                    {
                        connection.Open();
                        cantidad = (int)command.ExecuteScalar();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener la cantidad de visitantes por edificio y fecha: " + ex.Message);
                    }
                }
            }

            return cantidad;
        }

    }
}

