using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C_AD;
using C_Entidades;

namespace C_LN
{
    public class UsuarioController
    {
        private readonly UsuarioDAO usuarioDAO = new UsuarioDAO();

        public DataTable BuscarUsuarios(string nombreUsuario)
        {
            return usuarioDAO.BuscarUsuarios(nombreUsuario);
        }

        public void InsertarUsuario(string nombre, string apellido, DateTime fechaNacimiento, string nombreUsuario, string clave, string tipoUsuario)
        {
            usuarioDAO.InsertarUsuario(nombre, apellido, fechaNacimiento, nombreUsuario, clave, tipoUsuario);
        }

        public void ModificarUsuario(int idUsuario, string nombre, string apellido, DateTime fechaNacimiento, string nombreUsuario, string clave, string tipoUsuario)
        {
            usuarioDAO.ModificarUsuario(idUsuario, nombre, apellido, fechaNacimiento, nombreUsuario, clave, tipoUsuario);
        }

        public void EliminarUsuario(int idUsuario)
        {
            usuarioDAO.EliminarUsuario(idUsuario);
        }

        public DataTable ObtenerTodosLosUsuarios()
        {
            return usuarioDAO.ObtenerTodosLosUsuarios();
        }
        public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            return usuarioDAO.ObtenerUsuarioPorNombre(nombreUsuario);
        }
    }

}
