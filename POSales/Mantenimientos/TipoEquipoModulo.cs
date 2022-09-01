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

namespace POSales.Mantenimientos
{
    public partial class TipoEquipoModulo : Form
    {
        POSalesDb.TipoEquipo tipoEquipo = new POSalesDb.TipoEquipo();
        DBConnect dbcon = new DBConnect();
        public TipoEquipoModulo(POSalesDb.TipoEquipo tipoEquipo)
        {
            this.tipoEquipo = tipoEquipo;
            InitializeComponent();
            if (tipoEquipo.Id > 0)
            {
                btnSave.Visible = false;
            }
            else
            {
                btnUpdate.Visible = false;
            }
        }


        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de guardar este tipo quipo?", "Item Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtCodigoEquipo.Text))
                    {
                        MessageBox.Show("Por favor, ingrese el nombre del tipo equipo");
                    }

                    tipoEquipo.tipoEquipo = txtCodigoEquipo.Text;
                    dbcon.insertTipoEquipo(tipoEquipo);
                }
                MessageBox.Show("tipo Equipo guardado con exito");
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Estas seguro de actualizar este tipo quipo?", "Item Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtCodigoEquipo.Text))
                    {
                        MessageBox.Show("Por favor, ingrese el nombre del tipo equipo");
                    }

                    tipoEquipo.tipoEquipo = txtCodigoEquipo.Text;
                    dbcon.actualizarTipoEquipo(tipoEquipo);
                  
                }
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);   
            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
        public void Clear()
        {
            txtCodigoEquipo.Clear();
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
