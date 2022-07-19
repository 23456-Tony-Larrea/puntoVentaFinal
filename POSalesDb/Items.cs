using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;

namespace POSalesDb
{
   public class Items 
    {
		public int Id { get; set; }
		//agrega este campo ala base 
		public bool HasIva { get; set; }
		public string nombre { get; set; }
		public string codigoBarras { get; set; }
		public decimal precioA { get; set; }
		public decimal precioB { get; set; }
		public decimal precioC { get; set; }
		public decimal precioD { get; set; }
		public string descripcion { get; set; }
		public int stockMin { get; set; }
		public int stock { get; set; }
		public int unidad { get; set; }
		public int bId { get; set; }
		public int cId { get; set; }
		public int gId { get; set; }
		public int mId { get; set; }
		public bool servicio { get; set; }
		public bool hascombo { get; set; }
		public bool aplicaSeries { get; set; }
		public bool negativo { get; set; }
		public decimal ice { get; set; }
		public decimal valorIce { get; set; }
		public Bitmap imagen { get; set; }
		public string imagenUrl { get; set; }
		public decimal iva { get; set; }
		public List<Items> Combo { get; set; } = new List<Items>();
		public Categorias categoria { get; set; } = new Categorias();
		public Grupo grupo { get;set; } = new Grupo();
		public Marcas marcas { get; set; } = new Marcas();
		public Bodega Bodega { get; set; } = new Bodega();

		public decimal montoTotal { get; set; }
		[DisplayName("Precio total")]
		public decimal CostoTotal => (HasIva) ? montoTotal * iva * ice : montoTotal;

	}
}

