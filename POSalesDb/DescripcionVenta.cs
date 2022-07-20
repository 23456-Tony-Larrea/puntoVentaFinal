using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class DescripcionVenta
    {
        public int Id { get; set; }
        public int IdItem { get; set; }
        public int IdVenta { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public int cantidad { get; set; }
        public decimal montoTotal { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string tipoDocumento { get; set; }
        public Usuarios usuarios { get; set; }
        public Items items { get; set; }
        public Compras compras { get; set; }
    }
}
