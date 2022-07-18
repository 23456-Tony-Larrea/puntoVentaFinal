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

namespace POSales
{
    public partial class FacturaProveedor : Form
    {
        Provedeedores proveedor = new Provedeedores();
        List<Items> ItemsPorfactura = new List<Items>();
        Usuarios usuario = new Usuarios();
        Items Itemseleccionado = new Items();
        DBConnect dbcon = new DBConnect();
        decimal Subtotal = 0, iva = 0, TotalFactura = 0;
        int _idUsuario = 0;
        public FacturaProveedor(int IdUsuario)
        {
            _idUsuario = IdUsuario;
            InitializeComponent();
        }

        private void FacturaProveedor_Load(object sender, EventArgs e)
        {
            usuario = dbcon.selectUsuariosPorId(_idUsuario);
            label15.Text = usuario.nombre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            LookUpProduct supplier = new LookUpProduct();
            supplier.ShowDialog();
            Itemseleccionado = supplier.item;
            textBox6.Text = Itemseleccionado.codigoBarras;
            textBox7.Text = Itemseleccionado.nombre;
            comboBox2.Items.Add(Itemseleccionado.precioA);
            comboBox2.Items.Add(Itemseleccionado.precioB);
            comboBox2.Items.Add(Itemseleccionado.precioC);
            comboBox2.Items.Add(Itemseleccionado.precioD);
            txtPrice.Text = Itemseleccionado.stock.ToString();
        }

        private void LinFac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random rnd = new Random();
            textBox6.Clear();
            textBox6.Text += rnd.Next();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SuppliersForSales supplier = new SuppliersForSales();
            supplier.ShowDialog();
            proveedor = supplier.proveedores;
            textBox1.Text = proveedor.cedulaRuc;
            textBox2.Text = proveedor.proveedor;
            textBox3.Text = proveedor.direccion;
            textBox4.Text = proveedor.telefono;
            textBox5.Text = proveedor.email;
        }

        private void txtCant_TextChanged(object sender, EventArgs e)
        {
            int ComboIndex = -1;
            if (!string.IsNullOrEmpty(txtCant.Text))
            {
                if (comboBox2.SelectedIndex > ComboIndex)
                {
                    int cantidad = 0;
                    int.TryParse(txtCant.Text, out cantidad);
                    decimal Precio = 0,Subtotal = 0,ivaItem = 0;
                    decimal.TryParse(comboBox2.Text,out Precio);
                    decimal resultado = Precio * cantidad;
                    textBox9.Text = resultado.ToString();
                    if (Itemseleccionado.HasIva)
                    {
                        ivaItem = resultado * Itemseleccionado.iva/100;
                        textBox10.Text = ivaItem.ToString();

                    }
                    resultado += ivaItem;
                    txtTotal.Text = resultado.ToString();

                }
            }
        }
        private void Clear()
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in ggvProductos.Rows)
            {
                if (r.Cells["No"].ToString() == Itemseleccionado.codigoBarras)
                {
                    MessageBox.Show("Articulo ya ingresado!!");
                    return;
                }
            }
            decimal subTotalItem, totalItem, totalIvaItem;
            decimal.TryParse(textBox9.Text, out subTotalItem);
            decimal.TryParse(textBox10.Text, out totalIvaItem);
            decimal.TryParse(txtTotal.Text, out totalItem);
            Subtotal += subTotalItem;
            TotalFactura += totalItem;
            iva += totalIvaItem;
            ggvProductos.Rows.Add(Itemseleccionado.codigoBarras, Itemseleccionado.nombre, comboBox2.Text, txtCant.Text, txtTotal.Text);
            txtSubtotal.Text = Subtotal.ToString();
            textBox13.Text = TotalFactura.ToString();
            textBox12.Text = iva.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ClearPrice()
        {
            txtCant.Text = "";
            txtTotal.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearPrice();
        }
    }
}
