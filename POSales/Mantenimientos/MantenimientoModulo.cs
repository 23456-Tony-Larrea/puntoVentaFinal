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
    public partial class precioReferencial : Form
    {
        MantenimientoModel mantenimiento = new MantenimientoModel();
        Usuarios usuarios = new Usuarios();
        DBConnect dbcon = new DBConnect();
        int idUsuario;
        public precioReferencial(MantenimientoModel _mantenimiento,int IdUsuario)
        {
            this.idUsuario = IdUsuario;
            mantenimiento = _mantenimiento;
            InitializeComponent();
        }

        private void MantenimientoModulo_Load(object sender, EventArgs e)
        {
            usuarios = dbcon.selectUsuariosPorId(idUsuario);
            lblTecnico.Text = usuarios.nombre;
            txtOrdenServicio.Text = mantenimiento.equipo.descripcionEquipo;
            txtDescripcionFallo.Text = mantenimiento.descripcionFalla;
            txtSolucion.Text = mantenimiento.solucion;
            txtPrecio.Text = mantenimiento.precioReferencial.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (mantenimiento.idEstadoMantenimiento > 2)
            {
                MessageBox.Show("Ya no se puede modificar este mantenimiento");
                return;
            }
            decimal precioReferencial = 0;
            string Error = string.Empty;
            mantenimiento.idEstadoMantenimiento = 2;
            mantenimiento.fechaEntregaEquipo = DateTime.Now;
            mantenimiento.solucion = txtSolucion.Text;
            mantenimiento.idUsuarios = idUsuario;
            decimal.TryParse(txtPrecio.Text, out precioReferencial);
            mantenimiento.precioReferencial = precioReferencial;
            Error = dbcon.actualizarMantenimientoModel(mantenimiento);
            if (string.IsNullOrEmpty(Error))
            {
                MessageBox.Show("Actualizado Satisfactoriamente");
            }
            else
            {
                MessageBox.Show(Error);
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            POSales.Mantenimientos.ReservasModulo reserva = new POSales.Mantenimientos.ReservasModulo(mantenimiento.Id);
            reserva.ShowDialog();
            mantenimiento.reservas = reserva.ItemsFacturados;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                // Allow Digits and BackSpace char
            }
            else if (e.KeyChar == '.' && !((TextBox)sender).Text.Contains(','))
            {
                e.KeyChar = ',';
            }
            else if (e.KeyChar == ',' && !((TextBox)sender).Text.Contains(','))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
