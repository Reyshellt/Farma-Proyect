using C_AD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_LN
{
    public class VisitanteController
    {
        private readonly VisitanteDAO visitanteDAO = new VisitanteDAO();

        public DataTable BuscarVisitantePorNombre(string nombre)
        {
            return visitanteDAO.BuscarPorNombre(nombre);
        }

        public void InsertarVisitante(string nombre, string apellido, string carrera)
        {
            visitanteDAO.Insertar(nombre, apellido, carrera);
        }

        public void ModificarVisitante(int idVisitante, string nombre, string apellido, string carrera)
        {
            visitanteDAO.Modificar(idVisitante, nombre, apellido, carrera);
        }

        public void EliminarVisitante(int idVisitante)
        {
            visitanteDAO.Eliminar(idVisitante);
        }
        public DataTable ObtenerTodosLosVisitantes()
        {
            return visitanteDAO.ObtenerTodos();
        }
    }
}

