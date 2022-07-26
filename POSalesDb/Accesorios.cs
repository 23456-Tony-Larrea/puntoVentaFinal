using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace POSalesDb
{
    public class Accesorios
    {
        public int Id { get; set; }
        public string codigoEquipo { get; set; }
        public string accesoriosEquipo { get; set; }
        public Equipo equipo { get; set; }
        public int idEquipo { get; set; }
    }
}
