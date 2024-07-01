using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Entidades
{
    public class Visita
    {
        public int VisitaID { get; set; }
        public int UsuarioID { get; set; }
        public int? VisitanteID { get; set; }
        public int EdificioID { get; set; }
        public int AulaID { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime? HoraSalida { get; set; }
        public string MotivoVisita { get; set; }
        public byte[] FotoVisitante { get; set; }
    }
}
