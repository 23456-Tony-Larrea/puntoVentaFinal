
using POSalesDb;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POSales.Mantenimientos
{
    public partial class MarcaEquipoModulo : Form
    {
        DBConnect dbcon = new DBConnect();
        POSalesDb.MarcaEquipo Marca = new POSalesDb.MarcaEquipo();
        public MarcaEquipoModulo(POSalesDb.MarcaEquipo marca)
        {
            this.Marca = marca;
            InitializeComponent();
            if (marca.Id > 0)
            {
                btnUpdate.Visible = false;
            }
            else
            {
                btnUpdate.Visible = true;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de guardar este tipo equipo?", "Item Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtCodigoEquipo.Text))
                    {
                        MessageBox.Show("Por favor, ingrese el nombre del tipo equipo");
                    }
                    Marca.NombreMarcaEquipo = txtCodigoEquipo.Text;
                    dbcon.insertMarcaEquipo(Marca);
                }
                MessageBox.Show("tipo equipo insertado con exito");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de actualizar esta marca equipo?", "Item Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Marca.NombreMarcaEquipo = txtCodigoEquipo.Text;
                    dbcon.actualizarMarcaEquipo(Marca);

                }
                MessageBox.Show("marca de equipo actualizada con exito");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtCodigoEquipo.Text = "";
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}
