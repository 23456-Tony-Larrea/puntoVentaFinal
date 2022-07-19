using POSalesDb;
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

namespace POSales
{
    public partial class Adjustments : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        MainForm main;
        int _qty;
        public Adjustments(MainForm mn)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            main = mn;
            ReferenceNo();
            LoadStock();
            lblUsername.Text = main.lblUsername.Text;

        }

        public void ReferenceNo()
        {
            Random rnd = new Random();
            lblRefNo.Text = rnd.Next().ToString();
        }

        public void LoadStock()
        {
            int i = 0;
            dgvAdjustment.Rows.Clear();
            cm = new SqlCommand($"SELECT p.id, p.Nombre, p.codigoBarras, p.descripcion, b.marca, c.Categoria, p.precioA, p.stock,negativo FROM items AS p left JOIN Marcas AS b ON b.Id = p.bid left JOIN Categorias AS c on c.Id = p.cid WHERE CONCAT(p.Nombre,p.codigoBarras, b.marca, c.Categoria) LIKE '%{txtSearch}%'", cn);
            cn.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvAdjustment.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString());
            }
            dr.Close();
            cn.Close();
        }

        private void dgvAdjustment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAdjustment.Columns[e.ColumnIndex].Name;
            if (colName == "Select")
            {
                lblPcode.Text = dgvAdjustment.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblDesc.Text = dgvAdjustment.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + dgvAdjustment.Rows[e.RowIndex].Cells[4].Value.ToString() + " " + dgvAdjustment.Rows[e.RowIndex].Cells[5].Value.ToString();
                label8.Text = dgvAdjustment.Rows[e.RowIndex].Cells[5].Value.ToString();
                _qty = int.Parse(dgvAdjustment.Rows[e.RowIndex].Cells[8].Value.ToString());
               
                btnSave.Enabled = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadStock();
        }

        public void Clear()
        {
            lblDesc.Text = "";
            lblPcode.Text = "";
            txtQty.Clear();
            txtRemark.Clear();
            cbAction.Text = "";
            ReferenceNo();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            try
            {
                //validation for empty field
                if (cbAction.Text == "")
                {
                    MessageBox.Show("Seleccione la acción para agregar o reducir.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbAction.Focus();
                    return;
                }

                if (txtQty.Text == "")
                {
                    MessageBox.Show("Ingrese la cantidad para agregar o reducir.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtQty.Focus();
                    return;
                }

                if (txtRemark.Text == "")
                {
                    MessageBox.Show("Necesita motivo para el ajuste de existencias.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRemark.Focus();
                    return;
                }

                //update stock
                if (int.Parse(txtQty.Text) > _qty)
                {
                    MessageBox.Show("La cantidad de stock disponible debe ser mayor que la cantidad de ajuste.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbAction.Text == "Eliminar del inventario")
                {
                    int qty = 0;
                    int idItem = 0;
                    qty = int.Parse(txtQty.Text) * (-1);
                    dbcon.actualizarvalorStock(qty, label8.Text);
                }
                else if (cbAction.Text == "Agregar al Inventario")
                {
                    int qty = 0;
                    int idItem = 0;
                    idItem = int.Parse(lblPcode.Text);
                    qty = int.Parse(txtQty.Text);
                    dbcon.actualizarvalorStock(qty, label8.Text);
                }

                dbcon.ExecuteQuery("INSERT INTO Ajustamiento(referenceno, pcode, qty, action, remarks, sdate, [user]) VALUES ('" + lblRefNo.Text + "','" + lblPcode.Text + "','" + int.Parse(txtQty.Text) + "', '" + cbAction.Text + "', '" + txtRemark.Text + "', '" + DateTime.Now.ToShortDateString() + "','" + lblUsername.Text + "')");
                MessageBox.Show("El stock se ha ajustado con éxito.", "Proceso completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadStock();
                Clear();
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvAdjustment_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
