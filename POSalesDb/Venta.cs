using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class Venta
    {
        public int Id_venta { get; set; }
        public int numero { get; set; }
        public int Idcliente { get; set; }
        public int Idusuario { get; set; }
        public DateTime fecha_venta { get; set; }
        public decimal total { get; set; }
        public decimal iva { get; set; }
        public decimal subtotal { get; set; }
        public decimal descuento { get; set; }
        public Clientes cliente { get; set; } = new Clientes();
        public List<DescripcionVenta> venta { get; set; } = new List<DescripcionVenta>();
    }
}
