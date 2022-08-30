using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class MarcaEquipo
    {
        public int Id { get; set; }
        public string NombreMarcaEquipo { get; set; } //trata de mantener un standard  TipoEquipo, esta diferente al de SQL
    }
}
