using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class Reserva
    {
        public int Id { get; set; }
        public string estadoReserva { get; set; }
        public string codigoSerie { get; set; }
        public int IdestadoUsuario { get; set; }
    }
}
