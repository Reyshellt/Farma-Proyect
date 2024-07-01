using C_AD;
using C_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_LN
{
    public class VisitaBLL
    {

        private readonly VisitaDAL visitaDAL = new VisitaDAL();

        public DataTable ObtenerTodasLasVisitas()
        {
            return visitaDAL.ObtenerTodasLasVisitas();
        }

        public DataTable ObtenerInformacionVisitas()
        {
            return visitaDAL.ObtenerInformacionVisitas();
        }

        public Visita ObtenerVisitaPorID(int idVisita)
        {
            return visitaDAL.ObtenerVisitaPorID(idVisita);
        }

        public DataTable ObtenerVisitasPorIdVisitante(int idVisitante)
        {
            return visitaDAL.ObtenerVisitasPorIdVisitante(idVisitante);
        }

        public void InsertarVisita(Visita visita)
        {
            visitaDAL.InsertarVisita(visita);
        }

        public void ModificarVisita(Visita visita)
        {
            visitaDAL.ModificarVisita(visita);
        }

        public void EliminarVisita(int visitaID)
        {
            visitaDAL.EliminarVisita(visitaID);
        }

        public int ObtenerCantidadVisitantesPorEdificio(int edificioId)
        {
            return visitaDAL.ObtenerCantidadVisitantesPorEdificio(edificioId);
        }

        public int ObtenerCantidadVisitantesPorEdificioYFecha(int edificioId, DateTime fecha)
        {
            return visitaDAL.ObtenerCantidadVisitantesPorEdificioYFecha(edificioId, fecha);
        }
    }
}

