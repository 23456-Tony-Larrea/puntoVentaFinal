using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class MantenimientoModel
    {
        public int Id { get; set; }
        public DateTime fechaMantenimiento { get; set; }
        public DateTime fechaEntregaEquipo { get; set; }
        public int idEstadoMantenimiento { get; set; }
        public decimal precioReferencial { get; set; }
        public int IdEquipo { get; set; }
        public Equipo equipo { get; set; } = new Equipo();
        public int idUsuarios { get; set; }
        public int idOrdenServicio { get; set; }
        public Usuarios usuarios { get; set; }
        public EstadoMantenimiento estadoMantenimiento { get; set; }
        public List<Reserva> reservas { get; set; }
        public string descripcionFalla { get; set; }
        public string solucion { get; set; }
        public bool estadoAplicarCorreccion { get; set; }
        public bool estadoNoAplicarCorreccion { get; set; }
    }
}
