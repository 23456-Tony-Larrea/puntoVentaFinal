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
    public partial class LookUpProduct : Form
    {
        public Items item = new Items();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string type = string.Empty;

        public LookUpProduct(string tipo)
        {
            type = tipo;
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            if (tipo == "Factura")
            {
                LoadItemsForCashier();
            }
            else
            {
                LoadItemsForSuppliers();
            }
      
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadItemsForSuppliers()
        {
            int i = 0;
            DataTable Products = new DataTable();
            Products = dbcon.LoadItemsForSuppliers(txtSearch.Text);
            foreach(DataRow dr in Products.Rows)
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
        }
        public void LoadItemsForCashier()
        {
            int i = 0;
            DataTable Products = new DataTable();
            Products = dbcon.LoadItemsForSuppliers(txtSearch.Text);
            foreach (DataRow dr in Products.Rows)
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString());
            }
        }


        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            int Id = 0;
            if (e.RowIndex < 0)
            {
                return;

            }

            int.TryParse(dgvProduct.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out Id);
            if (colName == "Select")
            {
                if (MessageBox.Show("Añadir este artículo? ", "Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    item = dbcon.selectItemPorId(Id);
                    this.Close();
                }
         
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (type == "Factura")
            {
                LoadItemsForCashier();
            }
            else
            {
                LoadItemsForSuppliers();
            }
        }

        private void LookUpProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
