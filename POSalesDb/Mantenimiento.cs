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
        public DateTime fechaMantenimiento { get; set; }
        public DateTime fechaEntregaEquipo { get; set; }
        public int idEstadoMantenimiento { get; set; }
        public int idUsuarios { get; set; }
        public int idOrdenServicio { get; set; }
        public Usuarios usuarios { get; set; }
        public EstadoMantenimiento estadoMantenimiento { get; set; }
        public OrdenServicio OrdenServicio { get; set; }
        public string descripcionFalla { get; set; }
        public string solucion { get; set; }
        public bool estadoAplicarCorreccion { get; set; }
    }
}
