using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class DtoDetallesDeCompra
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int IdCompra { get; set; }
        public decimal precioCompra { get; set; }
        public decimal precioVenta { get; set; }
        public int cantidad { get; set; }
        public decimal montoTotal { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string tipoDocumento { get; set; }
    }
}
