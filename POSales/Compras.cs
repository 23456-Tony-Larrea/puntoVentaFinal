using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales
{
    public partial class Compras : Form
    {
        public Compras()
        {
            InitializeComponent();
        }

        private void Compras_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dBPOSaleDataSet.Compras' Puede moverla o quitarla según sea necesario.
            this.comprasTableAdapter.Fill(this.dBPOSaleDataSet.Compras);

        }
    }
}
