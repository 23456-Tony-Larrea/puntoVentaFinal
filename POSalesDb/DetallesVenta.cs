using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class DetallesVenta
    {
        public int Id { get; set; }
        public int IdItem { get; set; }
        public int IdFactura { get; set; }
        public decimal precioVenta { get; set; }
        public int cantidad { get; set; }
        public decimal montoTotal { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
