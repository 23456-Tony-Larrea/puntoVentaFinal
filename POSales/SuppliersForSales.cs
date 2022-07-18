using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POSalesDb;

namespace POSales
{
    public partial class SuppliersForSales : Form
    {
        public Provedeedores proveedores = new Provedeedores();
        DataTable ListaDeProveedores = new DataTable();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        public SuppliersForSales()
        {
            cn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            LoadSupplier();
        }
        public void LoadSupplier()
        {
            ListaDeProveedores = dbcon.SelectTodosLosProveedores();
            dgvSupplier.DataSource = ListaDeProveedores;
        }

        private void SuppliersForSales_Load(object sender, EventArgs e)
        {
            
        }

        private void dgvSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvSupplier.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                int DiasCredito = 0;
                proveedores.Id = (int)dgvSupplier.Rows[e.RowIndex].Cells["Id"].Value;
                proveedores.proveedor = dgvSupplier.Rows[e.RowIndex].Cells["proveedor"].Value.ToString();
                proveedores.direccion = dgvSupplier.Rows[e.RowIndex].Cells[3].Value.ToString();
                proveedores.contactPerson = dgvSupplier.Rows[e.RowIndex].Cells[4].Value.ToString();
                proveedores.telefono = dgvSupplier.Rows[e.RowIndex].Cells[5].Value.ToString();
                proveedores.email = dgvSupplier.Rows[e.RowIndex].Cells[6].Value.ToString();
                proveedores.fax = dgvSupplier.Rows[e.RowIndex].Cells[7].Value.ToString();
                proveedores.ciudad = dgvSupplier.Rows[e.RowIndex].Cells[12].Value.ToString();
                proveedores.pais = dgvSupplier.Rows[e.RowIndex].Cells[13].Value.ToString();
                proveedores.RazonSocial = dgvSupplier.Rows[e.RowIndex].Cells[8].Value.ToString();
                proveedores.cedulaRuc = dgvSupplier.Rows[e.RowIndex].Cells[9].Value.ToString();
                int.TryParse(dgvSupplier.Rows[e.RowIndex].Cells[10].Value.ToString(), out DiasCredito);
                proveedores.DiasCredito= DiasCredito;
                proveedores.paginaWeb = dgvSupplier.Rows[e.RowIndex].Cells[16].Value.ToString();
                proveedores.codPostal = dgvSupplier.Rows[e.RowIndex].Cells[15].Value.ToString();
                proveedores.provincia = dgvSupplier.Rows[e.RowIndex].Cells[14].Value.ToString();
                proveedores.estado = dgvSupplier.Rows[e.RowIndex].Cells[11].Value.ToString();
                this.Close();
            }
        }
    }
}
