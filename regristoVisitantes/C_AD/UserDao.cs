using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using C_AD;
using C_Entidades.cache;

namespace C_AD
{
    public class UserDao 
    {
        private readonly ConnectionToSql connectionToSql;

        public UserDao()
        {
            connectionToSql = ConnectionToSql.Instance;
        }

        public bool Login(string user, string clave)
        {
            using (var connection = connectionToSql.GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "EXEC ValidarCredenciales @user, @pass ";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", clave);
                    command.CommandType = CommandType.Text;
                    SqlDataReader Reader = command.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        while (Reader.Read())
                        {
                            cacheUserLogin.UsuarioID = Reader.GetInt32(0);
                            cacheUserLogin.Nombre = Reader.GetString(1);
                            cacheUserLogin.Apellido = Reader.GetString(2);
                            cacheUserLogin.TipoUsuario = Reader.GetString(4);
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
