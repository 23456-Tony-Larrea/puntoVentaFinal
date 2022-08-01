using System;
using System.Collections.Generic;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void dgvClients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
