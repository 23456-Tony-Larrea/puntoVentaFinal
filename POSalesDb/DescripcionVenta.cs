﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSalesDb
{
    public class DescripcionVenta
    {
        public int Id_descripcion_venta { get; set; }
        public int producto { get; set; }
        public int cantidad { get; set; }
        public int venta { get; set; }
        public decimal precio { get; set; }
    }
}
