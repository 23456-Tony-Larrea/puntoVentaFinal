using POSalesDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            POSalesDb.Compras compras = new POSalesDb.Compras();
            compras.Id = 10;
            Application.Run(new ReporteFactura(compras));
        }
    }
}
