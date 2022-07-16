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

namespace POSales
{
    public partial class combo : Form
    {
        DBConnect dbcon = new DBConnect();
        Items item = new Items();
        List<Items> items = new List<Items>();
        List<Items> Combos = new List<Items>();
        int _idProduct;
        public combo(int idProduct)
        {
            _idProduct = idProduct;
            InitializeComponent();
            LoadAllItems();
            LoadAllRelationItems();
        }
        private void LoadAllItems()
        {
            items = dbcon.selectTodosLosItemsSinCombo();
            dgvListaVisual.DataSource = items;
        }
        private void LoadAllRelationItems()
        {
            Combos = dbcon.selectCombo(_idProduct);
            dgvListaDeCombo.DataSource = Combos;
        }
        private void combo_Load(object sender, EventArgs e)
        {

        }

        private void dgvCombo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string Error = string.Empty;
            int IdProductoRelacionado = 0;
            string colName = dgvListaDeCombo.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (int.TryParse(dgvListaDeCombo.Rows[e.RowIndex].Cells["IdData"].Value.ToString(), out IdProductoRelacionado))
                {
                    Error = dbcon.deleteCombo(_idProduct, IdProductoRelacionado);
                    if (string.IsNullOrEmpty(Error))
                    {
                        Combos.RemoveAt(e.RowIndex);
                        dgvListaDeCombo.DataSource = new List<Items>();
                        dgvListaDeCombo.DataSource = Combos;
                        MessageBox.Show("Borrado Satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show(Error);
                    }
                }

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvListaVisual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            bool yaIngresado = false;
            string Error = string.Empty;
            int IdProductoRelacionado = 0;
            string colName = dgvListaVisual.Columns[e.ColumnIndex].Name;
            if (colName == "Add")
            {
                if (int.TryParse(dgvListaVisual.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out IdProductoRelacionado))
                {
                    foreach (DataGridViewRow Row in dgvListaDeCombo.Rows)
                    {
                        if(IdProductoRelacionado.ToString() == Row.Cells["idData"].Value.ToString())
                        {
                            MessageBox.Show("Este item ya ha sido ingresado");
                            return;
                        }
                    }

                    Error = dbcon.insertCombo(_idProduct, IdProductoRelacionado);
                    if (string.IsNullOrEmpty(Error))
                    {

                        Combos.Add(items.ElementAt(e.RowIndex));
                        dgvListaDeCombo.DataSource = new List<Items>();
                        dgvListaDeCombo.DataSource = Combos;
                        MessageBox.Show("Agregado Satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show(Error);
                    }
                }
               
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
