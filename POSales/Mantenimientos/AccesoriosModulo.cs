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
    public partial class AccesoriosModulo : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Punto de venta";
        public Accesorios accesorio = new Accesorios();
        bool Nuevo = false;
        public AccesoriosModulo(Accesorios acc,int idequipo)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            accesorio = acc;
            accesorio.idEquipo = idequipo;
            if (accesorio.Id > 0)
            {
                CargarAccesorios();
                btnSave.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
            }
        }

        private void CargarAccesorios()
        {
            txtIdAccesorios.Text = accesorio.Id.ToString();
            txtAccesoriosEquipo.Text = accesorio.accesoriosEquipo;
            txtCodigoEquipo.Text = accesorio.codigoEquipo;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtCodigoEquipo.Clear();
            txtAccesoriosEquipo.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            accesorio.accesoriosEquipo = txtAccesoriosEquipo.Text;
            accesorio.codigoEquipo = txtCodigoEquipo.Text ;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de actualizar este accesorio?", "Actualizar accesorios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtAccesoriosEquipo.Text))
                    {
                        MessageBox.Show("Por favor, ingrese los  Accesorios ");
                    }
                    accesorio.accesoriosEquipo = txtAccesoriosEquipo.Text;
                    accesorio.codigoEquipo = txtAccesoriosEquipo.Text;
                }
                DBConnect db = new DBConnect();
                string Error = db.actualizarAccesorios(accesorio);
                if (string.IsNullOrEmpty(Error))
                {
                    MessageBox.Show("Item actualizado con exito.", stitle);
                }
                else
                {
                    MessageBox.Show(Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccesoriosModulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(accesorio.codigoEquipo))
            {
                MessageBox.Show("debe asignar un codigo de accesorio para poder ingresarlo a un equipo");
            }
        }
    }
}


