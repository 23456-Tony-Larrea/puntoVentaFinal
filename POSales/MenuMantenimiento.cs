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
    public partial class MenuMantenimiento : Form
    {
        int idUsuarioFacturador = 0;
        public MenuMantenimiento(int idUsuarioFacturador)
        {
            this.idUsuarioFacturador = idUsuarioFacturador;
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

        private void MenuMantenimiento_Load(object sender, EventArgs e)
        {
            Form OrdendeServicio = new Mantenimientos.Mantenimiento(idUsuarioFacturador);
            openChildForm(OrdendeServicio);
        }

        private void btnOrdenProductos_Click(object sender, EventArgs e)
        {
            Mantenimientos.OrdenServicioModulo NuevaOrden = new Mantenimientos.OrdenServicioModulo(idUsuarioFacturador);
            NuevaOrden.ShowDialog();
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMantenimiento_Click(object sender, EventArgs e)
        {

        }
    }
}
