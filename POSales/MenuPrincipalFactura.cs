using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSales.Mantenimientos;
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
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnClientes_Click(object sender, EventArgs e)
        {
           Form client = new Clients();
            openChildForm(client);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            Form  factura = new ComprasProveedor(_idUsuario);
           factura.ShowDialog();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Mantenimientos.Mantenimientos clientModule = new Mantenimientos.Mantenimientos(_idUsuario);
            clientModule.ShowDialog();
        }

        private void btnOrdenMantenimiento_Click(object sender, EventArgs e)
        {
            Mantenimientos.OrdenServicioModulo orden = new Mantenimientos.OrdenServicioModulo(_idUsuario);
            orden.ShowDialog();

        }

        private void btnGenerarDaño_Click(object sender, EventArgs e)
        {
            Form listaOrdenes = new listaOrdenes();
            openChildForm(listaOrdenes);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Visible = true;
        }
    }
}
