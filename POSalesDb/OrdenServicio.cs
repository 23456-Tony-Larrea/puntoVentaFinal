using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class OrdenServicioModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int idCliente { get; set; }
        public int idUsuarios { get; set; }
        public Clientes cliente { get; set; }  = new Clientes();
        public Usuarios usuario { get; set; } = new Usuarios();
        public List<MantenimientoModel> mantenimientos { get; set; } = new List<MantenimientoModel>();
    }
}
