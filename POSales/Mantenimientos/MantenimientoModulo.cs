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
    public partial class MantenimientoModulo : Form
    {
        MantenimientoModel mantenimiento = new MantenimientoModel();
        Usuarios usuarios = new Usuarios();
        DBConnect dbcon = new DBConnect();
        int idUsuario;
        public MantenimientoModulo(MantenimientoModel _mantenimiento,int IdUsuario)
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

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Error = string.Empty;
            mantenimiento.idEstadoMantenimiento = 2;
            mantenimiento.fechaEntregaEquipo = DateTime.Now;
            mantenimiento.solucion = txtSolucion.Text;
            mantenimiento.idUsuarios = idUsuario;
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
    }
}
