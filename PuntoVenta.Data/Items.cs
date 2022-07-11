﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PuntoVenta.Data
{

	/// <summary>
	/// //https://codverter.com/src/sqltoclass?prg=1&db=1&sample=1
	/// </summary>

	public class Items
	{
		public int Id { get; set; }
		//agrega este campo ala base 
		public bool HasIva { get; set; }
		public string nombre { get; set; }
		public string codigoUno { get; set; }
		public string codigoDos { get; set; }
		public string codigoTres { get; set; }
		public string codigoCuatro { get; set; }
		public string codigoBarras { get; set; }
		public decimal precioA { get; set; }
		public decimal precioB { get; set; }
		public decimal precioC { get; set; }
		public decimal precioD { get; set; }
		public string descripcion { get; set; }
		public int unidadCaja { get; set; }
		public decimal peso { get; set; }
		public decimal comision { get; set; }
		public decimal descMax { get; set; }
		public int stockMin { get; set; }
		public int stockMax { get; set; }
		public decimal costo { get; set; }
		public int unidad { get; set; }
		public int bId { get; set; }
		public int cId { get; set; }
		public int gId { get; set; }
		public int mId { get; set; }
		public bool servicio { get; set; }
		public bool aplicaSeries { get; set; }
		public bool negativo { get; set; }
		public bool combo { get; set; }
		public bool gasto { get; set; }
		public string ice { get; set; }
		public string valorIce { get; set; }
		public byte[] imagen { get; set; }
		public string imagenUrl { get; set; }
		public decimal iva { get; set; }
		public decimal montoTotal { get; set; }

		[DisplayName("Precio total")]
		public decimal CostoTotal => (HasIva) ? montoTotal * iva * (Decimal.TryParse(ice, out var value) ? value : 0) : montoTotal;
	}
}
