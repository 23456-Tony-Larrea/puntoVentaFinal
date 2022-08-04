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
namespace POSales
{
    public partial class Clients : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        List<Clientes> clientes = new List<Clientes>();
        public Clientes cliente = new Clientes();
        SqlDataReader dr;

        public Clients()
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            cargarClientes(); 
        }

        public void cargarClientes()
        {
            int i = 0;
            clientes = dbcon.TodosLosClientes();
            dgvClients.DataSource = clientes;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClientModule clientModule = new ClientModule(cliente);
            clientModule.ShowDialog();
        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvClients.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                cliente = clientes.ElementAt(e.RowIndex);
                ClientModule clientModule = new ClientModule(cliente);
                clientModule.ShowDialog();
            }
            else
            {
                cliente = clientes.ElementAt(e.RowIndex);
                MessageBox.Show($"Ha seleccionado al cliente {cliente.nombre}");
                this.Close();
            }

        }


        private void Clients_Load(object sender, EventArgs e)
        {
        
        }
    }
}
