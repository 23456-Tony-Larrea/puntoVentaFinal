
using POSalesDb;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POSales.Mantenimientos
{
    public partial class MarcaEquipoModulo : Form
    {
        DBConnect dbcon = new DBConnect();
        POSalesDb.MarcaEquipo Marca = new POSalesDb.MarcaEquipo();
        public MarcaEquipoModulo(POSalesDb.MarcaEquipo marca)
        {
            this.Marca = marca;
            InitializeComponent();
            if (marca.Id > 0)
            {
                btnUpdate.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Marca.Nombre = txtCodigoEquipo.Text;
            dbcon.insertMarcaEquipo(Marca);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            Marca.Nombre = txtCodigoEquipo.Text;
            dbcon.actualizarMarcaEquipo(Marca);

        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
