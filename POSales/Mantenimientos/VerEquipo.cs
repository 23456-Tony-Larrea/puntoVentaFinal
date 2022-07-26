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

namespace POSales.Mantenimientos
{
    public partial class VerEquipo : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;
        public VerEquipo()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cargarEquipo();
        }

       public void cargarEquipo()
        {
            using (var repo = new Repository(new SqlConnection(dbcon.myConnection())))
            {
                dgvEquipo.DataSource = "";
                dgvEquipo.DataSource = dbcon.selectTodosLosItems();
            }
        }

        private void dgvEquipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvEquipo.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Equipo equipo = new Equipo();
                equipo.Id = Convert.ToInt32(dgvEquipo.Rows[e.RowIndex].Cells["Id"].Value);
                equipo.descripcionEquipo = Convert.ToString(dgvEquipo.Rows[e.RowIndex].Cells["descripcionEvento"].Value);
                equipo.descripcionFallo = Convert.ToString(dgvEquipo.Rows[e.RowIndex].Cells["descripcionFallo"].Value);
                equipo.codigo = Convert.ToString(dgvEquipo.Rows[e.RowIndex].Cells["codigo"].Value);
                equipo.series = Convert.ToString(dgvEquipo.Rows[e.RowIndex].Cells["series"].Value);
                Form equipoModule = new EquipoModulo(equipo);
                equipoModule.ShowDialog();
                cargarEquipo();
            }

            else if (colName == "Delete")
            {
                dgvEquipo.DataSource = null;
                if (MessageBox.Show("Estas seguro de eliminar este equipo?", "Eliminar Equipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("DELETE FROM Equipo WHERE id LIKE '" + dgvEquipo["id", e.RowIndex].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Equipo eliminado con exito.", "POS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            cargarEquipo();
        }
        }
}
