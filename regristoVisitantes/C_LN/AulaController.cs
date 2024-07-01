using C_AD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_LN
{
    public class AulaController
    {
        private readonly AulaDAO aulaDAO = new AulaDAO();
        //private readonly EdificioDAO edificioDAO = new EdificioDAO();

        public DataTable BuscarAulaPorNombre(string nombre)
        {
            return aulaDAO.BuscarPorNombre(nombre);
        }

        public void InsertarAula(string nombre, int edificioID)
        {
            aulaDAO.Insertar(nombre, edificioID);
        }

        public void ModificarAula(int idAula, string nombre, int edificioID)
        {
            aulaDAO.Modificar(idAula, nombre, edificioID);
        }

        public void EliminarAula(int idAula)
        {
            aulaDAO.Eliminar(idAula);
        }

        public DataTable ObtenerTodasLasAulas()
        {
            return aulaDAO.ObtenerTodos();
        }

        public DataTable BuscarAulaPorId(int idAula)
        {
            return aulaDAO.BuscarAulaPorId(idAula);
        }
        public DataTable ObtenerAulasPorEdificio(int edificioId)
        {
            return aulaDAO.ObtenerAulasPorEdificio(edificioId);
        }
    }
}
