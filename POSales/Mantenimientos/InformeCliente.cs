using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales.Mantenimientos
{
    public partial class InformeCliente : Form
    {
        public InformeCliente()
        {
            InitializeComponent();
        }

        private void InformeCliente_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }
    }
}
