using C_AD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_LN
{
    public class EdificioController
    {
        private readonly EdificioDAO edificioDAO = new EdificioDAO();

        public DataTable BuscarEdificioPorNombre(string nombre)
        {
            return edificioDAO.BuscarPorNombre(nombre);
        }

        public void InsertarEdificio(string nombre)
        {
            edificioDAO.Insertar(nombre);
        }

        public void ModificarEdificio(int idEdificio, string nombre)
        {
            edificioDAO.Modificar(idEdificio, nombre);
        }

        public void EliminarEdificio(int idEdificio)
        {
            edificioDAO.Eliminar(idEdificio);
        }

        public DataTable ObtenerTodosLosEdificios()
        {
            return edificioDAO.ObtenerTodos();
        }
        public string ObtenerNombreEdificioPorId(int idEdificio)
        {
            return edificioDAO.ObtenerNombreEdificioPorId(idEdificio);
        }

        public List<DateTime> ObtenerFechasEntradaEdificios()
        {
            return edificioDAO.ObtenerFechasEntradaEdificios();
        }
    }
}
