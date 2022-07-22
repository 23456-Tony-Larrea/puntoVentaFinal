using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class Equipo
    {
        public int Id { get; set; }
        public string codigo { get; set; }
        public string descripcionEquipo { get; set; }
        public string estado { get; set; }
        public string  accesoriosEquipo { get; set; }
        public int IdTecnico { get; set; }
    }
}
