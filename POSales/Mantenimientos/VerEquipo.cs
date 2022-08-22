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
        public VerEquipo()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cargarEquipo();
            this.idCliente = idCliente;
        }

       public void cargarEquipo()
        {
            int i = 1;
            ListaDeEquipos = dbcon.selectTodosLosEquipos();
            foreach (var equipo in ListaDeEquipos)
            {
                equipo.tipoEquipo = dbcon.selectTipoEquipoId(equipo.IdtipoEquipo);
                equipo.marcaEquipo = dbcon.selectMarcaEquipoId(equipo.IdMarcaEquipo);
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
        }

        private void VerEquipo_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                string Buscar = textBox1.Text;
                ListaDeEquipos.Where(x => x.codigo.Contains(Buscar) || x.descripcionEquipo.Contains(Buscar) || x.series.Contains(Buscar) || x.tipoEquipo.tipoEquipo.Contains(Buscar));
                int i = 1;
                dgvEquipo.Rows.Clear();
                foreach (var equipo in ListaDeEquipos)
                {
                    dgvEquipo.Rows.Add(i, equipo.Id, equipo.descripcionEquipo, equipo.codigo, equipo.series);
                    i++;
                }
            }
        }
    }
}
