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
        public string descripcionEquipo { get; set; }
        public string codigo { get; set; }
        public string  series { get; set; }
        public int idCliente { get; set; }
        public List<Accesorios> accesorios { get; set; } = new List<Accesorios>();
        public int Idmarca { get; set; }
        public MarcaEquipo marcaEquipo { get; set; } = new MarcaEquipo();
        public int IdtipoEquipo { get; set; }
        public TipoEquipo tipoEquipo { get; set; } = new TipoEquipo();
    }
}
