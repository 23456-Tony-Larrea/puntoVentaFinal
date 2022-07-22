using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class Mantenimiento
    {
        public int Id { get; set; }
        public string caracteristicas { get; set; }
        public int descripcionEquipo { get; set; }
        public string marca { get; set; }
        public string serie { get; set; }
        public string descripcionFalla { get; set; }
        public decimal precioReferencial { get; set; }
        public DateTime fechaMantenimiento { get; set; }
        public DateTime fechaEntregaEquipo { get; set; }
        public string historial { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuarios { get; set; }

    }
}
