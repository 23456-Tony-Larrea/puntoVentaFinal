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
    public partial class OrdenServicioModulo : Form
    {
        DBConnect dbcon = new DBConnect();
        Clientes cliente = new Clientes();
        private Form activeForm = null;
        OrdenServicioModel orden = new OrdenServicioModel();
        List<MantenimientoModel> mantenimientos = new List<MantenimientoModel>();


        List<Equipo> equipos = new List<Equipo>();
        Equipo equipoSeleccionado = new Equipo();
        public OrdenServicioModulo(int IdUsuario)
        {
            InitializeComponent();
 
            orden.idUsuarios = IdUsuario;
            orden.usuario = dbcon.selectUsuariosPorId(IdUsuario);
            lblCajero.Text = orden.usuario.nombre;
            Random rnd = new Random();
            textBox1.Text = rnd.Next().ToString();
 
        }
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel4.Controls.Add(childForm);
            panel4.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void cargarEquiposPorCliente()
        {
            advancedDataGridView1.DataSource = new List<Equipo>();
            equipos = dbcon.selectTodosLosEquiposPorCliente(cliente.Id);
            advancedDataGridView1.DataSource = equipos;
        }
        private void btnAggCliente_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            Clients FormCliente = new Clients();
            FormCliente.ShowDialog();
            cliente = FormCliente.cliente;
            TxtCiCliente.Text = cliente.ciRuc;
            TxtNombre.Text = cliente.nombre;
            TxtCelular.Text = cliente.celular;
            TxtEmail.Text = cliente.email;
            orden.idCliente = cliente.Id;
            panel4.Enabled = true;
            cargarEquiposPorCliente();
            txtDesFalla.Enabled = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void OrdenServicioModulo_Load(object sender, EventArgs e)
        {

        }

        private void advancedDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (advancedDataGridView1.SelectedRows.Count > (-1))
            {

                equipoSeleccionado = equipos.ElementAt(e.RowIndex);
                MessageBox.Show($"has seleccionado el equipo codigo {equipoSeleccionado.codigo}");
                txtDesFalla.Text = dbcon.selectFallaDeEquipo(equipoSeleccionado.Id);
                txtDesFalla.Enabled = true;
                dataGridView2.DataSource = new DataSet();
                dataGridView2.DataSource = dbcon.selectFallasDeEquipo(equipoSeleccionado.Id);

            }
           
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            if (equipoSeleccionado.Id > 0)
            {
                MantenimientoModel mantenimiento = new MantenimientoModel();
                mantenimiento.equipo = equipoSeleccionado;
                mantenimiento.IdEquipo = mantenimiento.equipo.Id;
                mantenimiento.fechaMantenimiento = DateTime.Now;
                mantenimiento.idEstadoMantenimiento = 1;
                mantenimiento.descripcionFalla = txtDesFalla.Text;
                mantenimientos.Add(mantenimiento);
                dataGridView1.DataSource = new MantenimientoModel();
                dataGridView1.DataSource = mantenimientos;
                txtDesFalla.Clear();
            }
            else
            {
                MessageBox.Show("Por favor seleccione un equipo");
            }
     

        }

        private void iconButton2_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > (-1))
            {
                mantenimientos.RemoveAt(dataGridView1.CurrentCell.RowIndex);
                dataGridView1.DataSource = new MantenimientoModel();
                dataGridView1.DataSource = mantenimientos;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int idOrden = 0;
            idOrden = dbcon.insertOrdenServicioModel(orden);
            if (idOrden > 0)
            {
                if (mantenimientos.Count > 0)
                {
                    foreach (var mantenimiento in mantenimientos)
                    {
                        mantenimiento.idOrdenServicio = idOrden;
                        mantenimiento.Codigo = textBox1.Text;
                        dbcon.insertMantenimientoModels(mantenimiento);
                    }
                }
                MessageBox.Show("Agregado Satisfactoriamente");
                this.Close();
            }
          
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            Equipo equipo = new Equipo();
            equipo.idCliente = cliente.Id;
            EquipoModulo verEquipos = new EquipoModulo(equipo);
            verEquipos.ShowDialog();
            cargarEquiposPorCliente();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
