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

namespace POSales.Mantenimientos
{
    public partial class TipoEquipoModulo : Form
    {
        POSalesDb.TipoEquipo tipoEquipo = new POSalesDb.TipoEquipo();
        DBConnect dbcon = new DBConnect();
        public TipoEquipoModulo(POSalesDb.TipoEquipo tipoEquipo)
        {
            this.tipoEquipo = tipoEquipo;
            InitializeComponent();
            if (tipoEquipo.Id > 0)
            {
                btnSave.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
            }
        }

        private void TipoEquipoModulo_Load(object sender, EventArgs e)
        {

        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tipoEquipo.tipoEquipo = txtCodigoEquipo.Text;
            dbcon.insertTipoEquipo(tipoEquipo);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            tipoEquipo.tipoEquipo = txtCodigoEquipo.Text;
            dbcon.actualizarTipoEquipo(tipoEquipo);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
