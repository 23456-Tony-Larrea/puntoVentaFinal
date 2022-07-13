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
using POSalesDB;
using POSalesDb;
namespace POSales
{
    public partial class ProductStockIn : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        string stitle = "Punto de venta";
        string _refNo;
        Enstock stockIn = new Enstock();

        public ProductStockIn(Enstock _stockIn)
        {
            stockIn = _stockIn;
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadProduct();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void LoadProduct()
        {
            int i = 0;
            dgvProduct.Rows.Clear();
            cm = new SqlCommand("SELECT codigo, pDesc, cantidad FROM Productos WHERE pDesc LIKE '%" + txtSearch.Text + "%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvProduct.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvProduct.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                if (MessageBox.Show("Añadir este artículo? ", stitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    addStockIn(e.RowIndex);
                    MessageBox.Show("Añadido existosamente", stitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        public void addStockIn(int index)
        {
 
            stockIn.pcode = dgvProduct.Rows[index].Cells[1].Value.ToString();
            stockIn.qty = Convert.ToInt32(dgvProduct.Rows[index].Cells[3].Value.ToString());
            stockIn.status = "Pending";
            try
            {
                dbcon.insertEnstock(stockIn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, stitle);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void ProductStockIn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void ProductStockIn_Load(object sender, EventArgs e)
        {

        }
    }
}
