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
        Accesorios accesorio;
        bool Nuevo = false;
        public AccesoriosModulo(Accesorios acc)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            accesorio = acc;
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
            txtSeriesEquipo.Text = accesorio.accesoriosEquipo;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtCodigoEquipo.Clear();
            txtSeriesEquipo.Clear();
            txtAccesoriosEquipo.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Nuevo)
            {
                accesorio = new Accesorios();
                CargarAccesorios();
                Nuevo = false;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Estas seguro de guardar este Accesorio?", "Accesorio Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (string.IsNullOrEmpty(txtAccesoriosEquipo.Text))
                        {
                            MessageBox.Show("Por favor, ingrese los accesorios");
                        }
                        Accesorios accesorios = new Accesorios();
                        accesorios.accesoriosEquipo = txtAccesoriosEquipo.Text;
                        accesorios.codigoEquipo = txtAccesoriosEquipo.Text;
                        DBConnect db = new DBConnect();
                        int Error = db.insertAccesorios(accesorios);
                        if (Error > 0)
                        {
                            MessageBox.Show("Accesorios ingresado  con exito.", stitle);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al insertar los datos", stitle);
                        }
                        btnSave.Text = "Nuevo";
                        Nuevo = true;
                        btnUpdate.Visible = true;
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }



            }
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
    }
}


