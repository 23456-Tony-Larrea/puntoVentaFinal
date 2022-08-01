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
    public partial class EquipoModulo : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Punto de venta";
        Equipo equipo = new Equipo();
        bool Nuevo = false;

        public EquipoModulo(Equipo eqp)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            equipo = eqp;
            if (equipo.Id > 0)
            {
                cargarEquipo();
                btnSave.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
            }
       
        }
        private void cargarEquipo()
        {
            txtIdEquipo.Text = equipo.Id.ToString();
            txtCodigoEquipo.Text = equipo.codigo;
            txtDescripcionEquipo.Text = equipo.descripcionEquipo;
            txtSeriesEquipo.Text = equipo.series;
            advancedDataGridView1.DataSource = equipo.accesorios;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void clear()
        {
         txtCodigoEquipo.Clear();
         txtDescripcionEquipo.Clear();
            txtSeriesEquipo.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            advancedDataGridView1.DataSource = new Accesorios();
            AccesoriosModulo accesorio = new AccesoriosModulo(new Accesorios(),equipo.Id);
            accesorio.ShowDialog();
            if (!string.IsNullOrEmpty(accesorio.accesorio.codigoEquipo))
            {
                equipo.accesorios.Add(accesorio.accesorio);
                advancedDataGridView1.DataSource = equipo.accesorios;
            }
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EquipoModulo_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            equipo.codigo= txtCodigoEquipo.Text;
            equipo.descripcionEquipo=  txtDescripcionEquipo.Text ;
            equipo.series=txtSeriesEquipo.Text;
            equipo.Id = dbcon.insertEquipos(equipo);
            foreach (var accesorio in equipo.accesorios)
            {
                dbcon.insertAccesorios(accesorio);
            }
               
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
