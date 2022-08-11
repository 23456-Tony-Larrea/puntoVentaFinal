using System;
using System.Windows.Forms;
using POSalesDb;
using System.Linq;
using System.Collections.Generic;

namespace POSales.Mantenimientos
{
    public partial class MarcaEquipo : Form
    {
        List<POSalesDb.MarcaEquipo> marcas = new List<POSalesDb.MarcaEquipo>();
        DBConnect dbcon = new DBConnect();
        public MarcaEquipo()
        {
            InitializeComponent();
        }
        private void cargarMarcas()
        {
            marcas = dbcon.TodosLasMarcasEquipo();
            dgvTipoEquipo.DataSource = new List<POSalesDb.MarcaEquipo>();
            dgvTipoEquipo.DataSource = marcas;
        }

        private void MarcaEquipo_Load(object sender, EventArgs e)
        {
            cargarMarcas();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
