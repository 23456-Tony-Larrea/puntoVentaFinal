﻿using POSalesDb;
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
               
                btnSave.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
            
            }
            CargarAccesorios();
        }

        private void CargarAccesorios()
        {
            txtIdAccesorios.Text = accesorio.Id.ToString();
            txtAccesoriosEquipo.Text = accesorio.accesoriosEquipo;
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtAccesoriosEquipo.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            accesorio.accesoriosEquipo = txtAccesoriosEquipo.Text;
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

     
        private void txtAccesoriosEquipo_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}


