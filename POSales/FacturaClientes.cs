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
using POSalesDB;
using POSalesDb;
namespace POSales
{
    public partial class FacturaClientes : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        SqlDataAdapter dr;
        Usuarios usuario = new Usuarios();
        List<Items> itemsPorFactura = new List<Items>();
        List<Clientes> clientes = new List<Clientes>();
        Clientes cliente = new Clientes();
        Items itemFactura = new Items();
        public FacturaClientes(int _idUser)
        {
            cn = new SqlConnection(dbcon.myConnection());
            InitializeComponent();
            GetRefNo();
            cargarCliente();
            cargarProductos();
            cargarUsuario(_idUser);


        }

        public void cargarCliente()
        {
            cboClientes.Items.Clear();
            clientes  =dbcon.selectTodosLosClientes();
            cboClientes.DataSource = clientes;
            cboClientes.DisplayMember = "nombre";
            cboClientes.ValueMember = "Id";
        }

        public void cargarUsuario(int _idUser)
        {
            usuario = dbcon.selectUsuariosPorId(_idUser);
            label4.Text += usuario.nombre;
        }
        public void cargarProductos()
        {
            cboProductos.Items.Clear();
            itemsPorFactura = dbcon.selectTodosLosItems();
            cboProductos.DataSource = itemsPorFactura;
            cboProductos.DisplayMember = "nombre";
            cboProductos.ValueMember = "id";
        }

        public void GetRefNo()
        {
            Random rnd= new Random();
            txtCodigo.Clear();
            txtCodigo.Text += rnd.Next();

        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cboProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            id = cboProductos.SelectedIndex;
            if (cboProductos.SelectedIndex > (-1))
            {
                itemFactura = itemsPorFactura.ElementAt(id);
            }
            switch (cliente.tipoCliente)
            {
                case "precioA":
                    txtPrice.Text = itemFactura.precioA.ToString();
                    break;
                case "precioB":
                    txtPrice.Text = itemFactura.precioB.ToString();
                    break;
                case "precioC":
                    txtPrice.Text = itemFactura.precioC.ToString();
                    break;
                case "precioD":
                    txtPrice.Text = itemFactura.precioD.ToString();
                    break;
            }

            txtUnit.Text = itemFactura.unidad.ToString();
            txtDescuento.Text = itemFactura.descMax.ToString();

            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            calcular();
        }
        private void calcular()
        {
            decimal calculo = 0, calculo2 = 0 ;


            switch (cliente.tipoCliente)
            {
                case "precioA":
                    calculo = (itemFactura.precioA - (itemFactura.precioA * (itemFactura.descMax / 100))) + ((itemFactura.precioA - (itemFactura.precioA * (itemFactura.descMax / 100))) * itemFactura.iva);
                    calculo2 =  itemFactura.precioA* itemFactura.iva;
                    ggvProductos.Rows.Add(itemFactura.Id,itemFactura.nombre, itemFactura.precioA, calculo2, itemFactura.unidad,calculo);
                    break;
                case "precioB":
                    calculo = (itemFactura.precioB - (itemFactura.precioB * (itemFactura.descMax / 100))) + ((itemFactura.precioB - (itemFactura.precioB * (itemFactura.descMax / 100))) * itemFactura.iva);
                    calculo2 = itemFactura.precioB * itemFactura.iva;
                    ggvProductos.Rows.Add(itemFactura.Id, itemFactura.nombre, itemFactura.precioB, calculo2, itemFactura.unidad,calculo);
                    break;
                case "precioC":
                    calculo = (itemFactura.precioC - (itemFactura.precioC * (itemFactura.descMax / 100))) + ((itemFactura.precioC - (itemFactura.precioC * (itemFactura.descMax / 100))) * itemFactura.iva);
                    calculo2 = itemFactura.precioC * itemFactura.iva;
                    ggvProductos.Rows.Add(itemFactura.Id, itemFactura.nombre, itemFactura.precioC, calculo2, itemFactura.unidad,calculo);
                    break;
                case "precioD":
                    calculo = (itemFactura.precioD - (itemFactura.precioD * (itemFactura.descMax / 100))) + ((itemFactura.precioD - (itemFactura.precioD * (itemFactura.descMax / 100))) * itemFactura.iva);
                    calculo2 = itemFactura.precioD * itemFactura.iva;
                    ggvProductos.Rows.Add(itemFactura.Id, itemFactura.nombre, itemFactura.precioD, calculo2, itemFactura.unidad,calculo);
                    break;
            }

            decimal subtotal = 0;
            if (ggvProductos.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in ggvProductos.Rows)
                {
                    decimal totalenRow = 0;
                    decimal.TryParse(row.Cells["total"].ToString(), out totalenRow);
                    subtotal += totalenRow;
                }

            }
            balance.Text = subtotal.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            int.TryParse(cboClientes.ValueMember, out id);
            cboClientes.Enabled = false;
            id++;
            cliente = clientes.ElementAt(cboClientes.SelectedIndex);
        }

        private void txtCant_TextChanged(object sender, EventArgs e)
        {
            decimal precio = 0, total = 0;
            int cantidad = 0;
            decimal.TryParse(txtPrice.Text, out precio);
            int.TryParse(txtCant.Text, out cantidad);
            total = precio * cantidad;
            txtTotal.Text = total.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = ggvProductos.CurrentCell.RowIndex;
            if (ggvProductos.Rows.Count > 0)
            {
                if (ggvProductos.SelectedRows.Count > 0)
                {
                    ggvProductos.Rows.RemoveAt(index);
                }
            }
        }

        private void txtCant_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
