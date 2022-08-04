using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using POSalesDb;

namespace POSales.Mantenimientos
{
    public partial class SeleccionarCliente : Form
    {
        List<OrdenServicioModel> ordenes = new List<OrdenServicioModel>();
        DBConnect dbcon = new DBConnect();
        public SeleccionarCliente()
        {
            InitializeComponent();
        }

        private void OrdenServicio_Load(object sender, EventArgs e)
        {
            int i = 1;
            ordenes = dbcon.selectTodosLasOrdenServicioModel();
            foreach(var orden in ordenes)
            {
                dgvClients.Rows.Add(i, orden.Id, orden.cliente.nombre, orden.Descripcion, orden.idCliente, orden.idUsuarios);
                i++;
            }
        }
        public void cargarClientesFiltrados()
        {
            string NombreCliente = $" [nombre] LIKE '%{textBox1.Text}%'";
            string comercioCliente = $" OR [comercio] LIKE '%{textBox1.Text}%'";
            string codigoCliente = $" OR [codigo] LIKE '%{textBox1.Text}%'";
            string fechaNacimientoCliente = $" OR [fechaNacimiento] LIKE '%{textBox1.Text}%'";
            string fechaRegistroCliente = $" OR [fechaRegistro] LIKE '%{textBox1.Text}%'";
            string ciudadCliente = $"OR [ciudad] LIKE '%{textBox1.Text}%'";
            string tipoCliente = $" OR [tipo] LIKE '%{textBox1.Text}%'";
            string ciRucCliente = $" OR [ciRuc] LIKE '%{textBox1.Text}%'";
            string paisCliente = $" OR [pais] LIKE '%{textBox1.Text}%'";
            string estadoCliente = $" OR [estado] LIKE '%{textBox1.Text}%'";
            string direccionCliente = $" OR [direccion] LIKE '%{textBox1.Text}%'";
            string telefonoCliente = $" OR [telefono] LIKE '%{textBox1.Text}%'";
            string celularCliente = $" OR [celular] LIKE '%{textBox1.Text}%'";
            string faxCliente = $" OR [fax] LIKE '%{textBox1.Text}%'";
            string cargonCliente = $" OR [cargo] LIKE '%{textBox1.Text}%'";
            string emailCliente = $" OR [email] LIKE '%{textBox1.Text}%'";
            string tipoCCliente = $" OR [tipoCliente] LIKE '%{textBox1.Text}%'";

            ((DataTable)dgvClients.DataSource).DefaultView.RowFilter = NombreCliente +
                 comercioCliente + codigoCliente + fechaNacimientoCliente + fechaRegistroCliente +
                 ciudadCliente + tipoCliente + ciRucCliente + paisCliente + estadoCliente + direccionCliente +
                 telefonoCliente + celularCliente + faxCliente + cargonCliente + emailCliente + tipoCCliente;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           Clients clients = new Clients();
            clients.ShowDialog();
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        cargarClientesFiltrados();
        }
    }
}
