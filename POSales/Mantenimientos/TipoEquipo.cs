using System;
using POSalesDb;
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
    public partial class TipoEquipo : Form
    {
        List<POSalesDb.TipoEquipo> tipoEquipos = new List<POSalesDb.TipoEquipo>();
        DBConnect dbcon = new DBConnect();
        public TipoEquipo()
        {
            tipoEquipos = dbcon.TodosLosTipoEquipos();
            InitializeComponent();
            cargarTipoEquipos();
        }
        private void cargarTipoEquipos()
        {
            dgvTipoEquipo.DataSource = new List<POSalesDb.TipoEquipo>();
            dgvTipoEquipo.DataSource = tipoEquipos;
        }

        private void dgvTipoEquipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void TipoEquipo_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TipoEquipoModulo tipoEquipoModulo = new TipoEquipoModulo(new POSalesDb.TipoEquipo());
            tipoEquipoModulo.ShowDialog();
            cargarTipoEquipos();
        }
    }
}
