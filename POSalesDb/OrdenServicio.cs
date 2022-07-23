using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class OrdenServicio
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int idCliente { get; set; }
        public int idUsuarios { get; set; }
    }
}
