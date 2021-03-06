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
using System.IO;
namespace POSales.Mantenimientos
{
    public partial class VerAccesorios : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public VerAccesorios()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cargarAccesorios();
        }
        public void cargarAccesorios()
        {
            using (var repo = new Repository(new SqlConnection(dbcon.myConnection())))
            {
                dgvAccesorios.DataSource = "";
                dgvAccesorios.DataSource = dbcon.selectTodosLosAccesorios();
            }
        }

        private void dgvAccesorios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAccesorios.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Accesorios accesorios = new Accesorios();
                accesorios.Id = Convert.ToInt32(dgvAccesorios.Rows[e.RowIndex].Cells["Id"].Value);
                accesorios.codigoEquipo = Convert.ToString(dgvAccesorios.Rows[e.RowIndex].Cells["codigoEquipo"].Value);
                accesorios.codigoEquipo = Convert.ToString(dgvAccesorios.Rows[e.RowIndex].Cells["accesoriosEquipo"].Value);
                accesorios.idEquipo = Convert.ToInt32(dgvAccesorios.Rows[e.RowIndex].Cells["idEquipo"].Value);
                Form accesoriosModulo = new AccesoriosModulo(accesorios);
                accesoriosModulo.ShowDialog();
                cargarAccesorios();
            }
            else if (colName == "Delete")
            {
                dgvAccesorios.DataSource = null;
                if (MessageBox.Show("Estas seguro de eliminar este Accesorio?", "Eliminar Accesorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Accesorios WHERE id LIKE '" + dgvAccesorios["id", e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Accesorio eliminado con exito.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            cargarAccesorios();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Accesorios accesorios = new Accesorios();
            AccesoriosModulo accesoriosModulo = new AccesoriosModulo(accesorios);
            accesoriosModulo.ShowDialog();
            cargarAccesorios();
        }
    }

}
