using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSalesDb;

namespace POSales
{
    public partial class MenuPrincipalFactura : Form
    {
        int _idUsuario;
        public MenuPrincipalFactura(int idUsuario)
        {
            _idUsuario =idUsuario;
            InitializeComponent();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            ComprasProveedor factura = new ComprasProveedor(_idUsuario);
            factura.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picClientes_Click(object sender, EventArgs e)
        {
            ClientModule clientModule = new ClientModule(new Clientes());
            clientModule.ShowDialog();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Mantenimientos.SeleccionarMantenimiento clientModule = new Mantenimientos.SeleccionarMantenimiento(_idUsuario);
            clientModule.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Mantenimientos.OrdenServicioModulo orden = new Mantenimientos.OrdenServicioModulo(_idUsuario);
            orden.ShowDialog();
        }
    }
}
