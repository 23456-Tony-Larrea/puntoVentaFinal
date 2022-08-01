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
        List<Equipo> ListaDeEquipos = new List<Equipo>();
        int idCliente;
        SqlDataReader dr;
        public VerEquipo(int idCliente)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cargarEquipo();
            this.idCliente = idCliente;
        }

       public void cargarEquipo()
        {
            int i = 1;
            ListaDeEquipos = dbcon.selectTodosLosEquiposPorCliente(idCliente);
            foreach (var equipo in ListaDeEquipos)
            {
                dgvEquipo.Rows.Add(i,equipo.Id,equipo.descripcionEquipo,equipo.codigo,equipo.series);
                i++;
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
                equipo.codigo = Convert.ToString(dgvEquipo.Rows[e.RowIndex].Cells["codigo"].Value);
                equipo.series = Convert.ToString(dgvEquipo.Rows[e.RowIndex].Cells["series"].Value);
                Form equipoModule = new EquipoModulo(equipo);
                equipoModule.ShowDialog();
                cargarEquipo();
            }
            colName = dgvEquipo.Columns[e.ColumnIndex].Name;
            if (colName == "Selected")
            {
                if (dgvEquipo.Rows[e.RowIndex].Cells["Selected"].Value == null)
                {
                    dgvEquipo.Rows[e.RowIndex].Cells["Selected"].Value = true;
                }
                else
                {
                    string variable = dgvEquipo.Rows[e.RowIndex].Cells["Selected"].Value.ToString();
                    if (variable == "False")
                    {
                        dgvEquipo.Rows[e.RowIndex].Cells["Selected"].Value = true;
                    }
                    else if (variable == "True")
                    {
                        dgvEquipo.Rows[e.RowIndex].Cells["Selected"].Value = false;
                    }
                }

            }
        }

        private void VerEquipo_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form equipoModule = new EquipoModulo(new Equipo());

        }
    }
}
