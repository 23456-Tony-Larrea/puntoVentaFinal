using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class Compras
    {
        public int Id { get; set; }
        public string tipoCompra { get; set; }
        public string codigoCompra { get; set; }
        public int idUsuario { get; set; }
        public int idProveedor { get; set; }
        public DateTime fecha { get; set; }
        public string formaPago { get; set; }
        public decimal subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal IvaPrecio { get; set; }
        public decimal total { get; set; }
        public Usuarios usuarios { get; set; } = new Usuarios();
    }
}
