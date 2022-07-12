using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
  public class Usuarios
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string contraseña { get; set; }
        public string role { get; set; }
        public string nombre { get; set; }
        public string isactive { get; set; }

    }
}
