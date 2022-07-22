using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public  class Tecnicos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ci { get; set; }
        public string Telefono { get; set; }
        public string correo { get; set; }
        public string estadoTecnico { get; set; }

        public int idMantenimiento { get; set; }


    }
}
