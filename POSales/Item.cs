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
using POSalesDB;
using System.IO;

namespace POSales
{
    public partial class Item : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
         DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public Item()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cargarItem();
        }
        public void cargarItem()
        {
            using (var repo = new Repository(new SqlConnection(dbcon.myConnection())))
            {
                dgvItem.DataSource = "";
                dgvItem.DataSource = dbcon.selectTodosLosItems();


            }
        }
        
        private void dgvBodega_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string colName = dgvItem.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Items item = new Items();
                item.Id = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["Id"].Value);
                item.nombre = dgvItem.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                item.codigoBarras = dgvItem.Rows[e.RowIndex].Cells["codigoBarras"].Value.ToString();
                item.precioA = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["precioA"].Value.ToString());
                item.precioB = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["precioB"].Value.ToString());
                item.precioC = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["precioC"].Value.ToString());
                item.precioD = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["precioD"].Value.ToString());
                item.precioD = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["precioD"].Value.ToString());
                item.descripcion = dgvItem.Rows[e.RowIndex].Cells["descripcion"].Value.ToString();
                item.descMax = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["descMax"].Value.ToString());
                item.stockMin = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["stockMin"].Value.ToString());
                item.costo = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["costo"].Value.ToString());
                item.unidad = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["unidad"].Value.ToString());
                item.bId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["bId"].Value.ToString());
                item.cId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["CId"].Value.ToString());
                item.gId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["gId"].Value.ToString());
                item.mId = Convert.ToInt32(dgvItem.Rows[e.RowIndex].Cells["mId"].Value.ToString());
                item.servicio = Convert.ToBoolean(dgvItem.Rows[e.RowIndex].Cells["servicio"].Value);
                item.aplicaSeries = Convert.ToBoolean(dgvItem.Rows[e.RowIndex].Cells["aplicaSeries"].Value.ToString());
                item.negativo = Convert.ToBoolean(dgvItem.Rows[e.RowIndex].Cells["negativo"].Value.ToString());
                item.combo = Convert.ToBoolean(dgvItem.Rows[e.RowIndex].Cells["Combo"].Value.ToString());
                item.ice = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["ice"].Value.ToString());
                item.valorIce = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["valorIce"].Value.ToString());
                item.iva = Convert.ToDecimal(dgvItem.Rows[e.RowIndex].Cells["iva"].Value.ToString());
                item.HasIva = Convert.ToBoolean(dgvItem.Rows[e.RowIndex].Cells["HasIva"].Value.ToString());
                item.imagen =dgvItem.Rows[e.RowIndex].Cells["imagen"].Value.ToString();
                Form itemModule = new ProveedorFactura(item); 
                itemModule.Show();
            
            
            }
            else if (colName == "Delete")
            {
                dgvItem.DataSource = null;
                if (MessageBox.Show("Estas seguro de eliminar este Item?", "Eliminar Item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Bodega WHERE id LIKE '" + dgvItem["id", e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Item eliminado con exito.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            cargarItem();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Items item = new Items();
            ProveedorFactura productModule = new ProveedorFactura(item);
            productModule.ShowDialog();
        }

        private void Item_Load(object sender, EventArgs e)
        {

        }

        private void dgvItem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgvItem.Columns[e.ColumnIndex].Name == "imagenDataGridViewImageColumn")
            {
                byte[] be = Encoding.ASCII.GetBytes(this.dgvItem.Rows[e.RowIndex].Cells["imagenDataGridViewImageColumn"].Value.ToString());
                Bitmap bmp;
                using (var ms = new MemoryStream(be))
                {
                    this.dgvItem.Rows[e.RowIndex].Cells["ImagenBitmap"].Value = new Bitmap(ms);
                }
            }
        }
    }
}
