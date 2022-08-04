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
        public int idItem { get; set; }
        public Items items { get; set; }
        public decimal precioReferencial { get; set; }
        public decimal precioFinal { get; set; }
        public decimal precioUnitario { get; set; }
    }
}
