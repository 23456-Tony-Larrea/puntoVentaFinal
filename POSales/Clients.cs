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
using POSalesDb;
using POSalesDB;
namespace POSales
{
    public partial class Clients : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataReader dr;

        public Clients()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cargarClientes(); 
        }

        public void cargarClientes()
        {
            using (var repo = new Repository(new SqlConnection(dbcon.myConnection())))
            {
                dgvClients.DataSource = "";
                dgvClients.DataSource = dbcon.TodosLosClientes();


            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Clientes cliente = new Clientes();
            ClientModule clientModule = new ClientModule(cliente);
            clientModule.ShowDialog();
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvClients.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                Clientes cliente = new Clientes();
                cliente.Id = Convert.ToInt32(dgvClients.Rows[e.RowIndex].Cells["Id"].Value);
                cliente.nombre= dgvClients.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
                cliente.codigo = dgvClients.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                cliente.comercio = dgvClients.Rows[e.RowIndex].Cells["comercio"].Value.ToString();
                cliente.codigo = dgvClients.Rows[e.RowIndex].Cells["codigo"].Value.ToString();
                cliente.fechaNacimiento= Convert.ToDateTime(dgvClients.Rows[e.RowIndex].Cells["fechaNacimiento"].Value.ToString());
                cliente.fechaRegistro = Convert.ToDateTime(dgvClients.Rows[e.RowIndex].Cells["fechaRegistro"].Value.ToString());
                cliente.ciudad = dgvClients.Rows[e.RowIndex].Cells["ciudad"].Value.ToString();
                cliente.tipo= dgvClients.Rows[e.RowIndex].Cells["tipo"].Value.ToString();
                cliente.ciRuc = dgvClients.Rows[e.RowIndex].Cells["ciRuc"].Value.ToString();
                cliente.pais = dgvClients.Rows[e.RowIndex].Cells["pais"].Value.ToString();
                cliente.estado = dgvClients.Rows[e.RowIndex].Cells["estado"].Value.ToString();
                cliente.direccion = dgvClients.Rows[e.RowIndex].Cells["direccion"].Value.ToString();
                cliente.telefono = dgvClients.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                cliente.celular = dgvClients.Rows[e.RowIndex].Cells["celular"].Value.ToString();
                cliente.fax = dgvClients.Rows[e.RowIndex].Cells["fax"].Value.ToString();
                cliente.cargo = dgvClients.Rows[e.RowIndex].Cells["cargo"].Value.ToString();
                cliente.email= dgvClients.Rows[e.RowIndex].Cells["eail"].Value.ToString();
                cliente.tipoCliente = dgvClients.Rows[e.RowIndex].Cells["tipoCliente"].Value.ToString();
                Form clienteModule = new ClientModule(cliente);
                clienteModule.Show();
            }
        }
    }
}
