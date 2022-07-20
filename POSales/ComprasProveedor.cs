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
    public partial class ComprasProveedor : Form
    {
        Provedeedores proveedor = new Provedeedores();
        List<Items> ItemsPorfactura = new List<Items>();
        Usuarios usuario = new Usuarios();
        Items Itemseleccionado = new Items();
        DBConnect dbcon = new DBConnect();
        decimal Subtotal = 0, iva = 0, TotalFactura = 0;
        int _idUsuario = 0;
        public ComprasProveedor(int IdUsuario)
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
            LookUpProduct supplier = new LookUpProduct("");
            supplier.ShowDialog();
            Itemseleccionado = supplier.item;
            textBox6.Text = Itemseleccionado.codigoBarras;
            textBox7.Text = Itemseleccionado.nombre;
            txtStock.Text = Itemseleccionado.stock.ToString();
        }

        private void LinFac_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Random rnd = new Random();
            txtCodigo.Clear();
            txtCodigo.Text += rnd.Next();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            POSalesDb.Compras factura = new POSalesDb.Compras();
            factura.codigoCompra = txtCodigo.Text;
            factura.idUsuario = _idUsuario;
            factura.total = Convert.ToDecimal(txtTotal.Text);
            factura.subtotal = Convert.ToDecimal(txtSubtotal.Text);
            factura.IvaPrecio = Convert.ToDecimal(txtIvaItem.Text);
            factura.tipoCompra = comboBox1.Text;
            factura.idProveedor = proveedor.Id;
            int idFactura = dbcon.insertCompras(factura);
            if (idFactura > 0)
            {
                factura.Id = idFactura;
                string Error = string.Empty;
                if (ggvProductos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow r in ggvProductos.Rows)
                    {

                        int qty = 0;
                        int idItem = 0;
                        Detalle_Compra detalle_Compra = new Detalle_Compra();
                        detalle_Compra.IdCompra = idFactura;
                        detalle_Compra.IdItem = int.Parse(r.Cells["id"].Value.ToString());
                        detalle_Compra.cantidad = int.Parse(r.Cells["cantidad"].Value.ToString());
                        detalle_Compra.precioCompra = decimal.Parse(r.Cells["precio"].Value.ToString());
                        detalle_Compra.montoTotal = decimal.Parse(r.Cells["total"].Value.ToString());
                        idItem = int.Parse(r.Cells["id"].Value.ToString());
                        qty = int.Parse(r.Cells["cantidad"].Value.ToString());
                        dbcon.insertDetallesCompras(detalle_Compra);
                        dbcon.actualizarvalorStock(qty, idItem);

                    }

                }
                if (string.IsNullOrEmpty(Error))
                {

                }

            }
            else
            {
                MessageBox.Show("Error al insertar factura");
                return;
            }

            ReporteFactura reporte = new ReporteFactura(factura);
            reporte.Show();



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
            if (!string.IsNullOrEmpty(txtCant.Text))
            {
                if (!string.IsNullOrEmpty(txtPrecio.Text))
                {
                    int cantidad = 0;
                    int.TryParse(txtCant.Text, out cantidad);
                    decimal Precio = 0,Subtotal = 0,ivaItem = 0;
                    decimal.TryParse(txtPrecio.Text,out Precio);
                    decimal resultado = Precio * cantidad;
                    txtSubTotalItem.Text = resultado.ToString();
                    if (Itemseleccionado.HasIva)
                    {
                        ivaItem = resultado * Itemseleccionado.iva/100;
                        txtIvaItem.Text = ivaItem.ToString();

                    }
                    resultado += ivaItem;
                    txtTotalItem.Text = resultado.ToString();

                }
            }
        }
        private void Clear()
        {
            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Itemseleccionado.Id == 0)
            {
                MessageBox.Show("Debe ingresar un producto");
                return;
            }
            if (string.IsNullOrEmpty(txtPrecio.Text) || txtPrecio.Text == "0")
            {
                MessageBox.Show("Debe ingresar un precio");
                return;
            }
            if (string.IsNullOrEmpty(txtCant.Text) || txtCant.Text == "0")
            {
                MessageBox.Show("Debe ingresar una cantidad del producvto");
                return;
            }
            foreach (DataGridViewRow r in ggvProductos.Rows)
            {
                if (r.Cells["No"].ToString() == Itemseleccionado.codigoBarras)
                {
                    MessageBox.Show("Articulo ya ingresado!!");
                    return;
                }
            }
            decimal subTotalItem, totalItem, totalIvaItem;
            decimal.TryParse(txtSubTotalItem.Text, out subTotalItem);
            decimal.TryParse(txtIvaItem.Text, out totalIvaItem);
            decimal.TryParse(txtTotalItem.Text, out totalItem);
            Subtotal += subTotalItem;
            TotalFactura += totalItem;
            iva += totalIvaItem;
            ggvProductos.Rows.Add(Itemseleccionado.Id,Itemseleccionado.codigoBarras, Itemseleccionado.nombre, txtPrecio.Text, txtCant.Text,totalIvaItem.ToString(),subTotalItem.ToString(), txtTotalItem.Text);
            txtSubtotal.Text = Subtotal.ToString();
            txtTotal.Text = TotalFactura.ToString();
            txtIva.Text = iva.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (ggvProductos.SelectedRows.Count > (-1))
            {
                foreach (DataGridViewRow r in ggvProductos.SelectedRows)
                {
                    decimal subTotalItem, totalItem, totalIvaItem;
                    decimal.TryParse(r.Cells["subtotalPorItem"].Value.ToString(), out subTotalItem);
                    decimal ivaItem = 0;

                    decimal.TryParse(r.Cells["ivaPorItem"].Value.ToString(), out totalIvaItem);
                    decimal.TryParse(r.Cells["total"].Value.ToString(), out totalItem);
                    Subtotal -= subTotalItem;
                    TotalFactura -= totalItem;
                    iva -= totalIvaItem;
                    ggvProductos.Rows.Remove(r);
                }
            }

          
           
            txtSubtotal.Text = Subtotal.ToString();
            txtTotal.Text = TotalFactura.ToString();
            txtIva.Text = iva.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Recept recept = new Recept();
            //recept.LoadRecept(label12.Text, .Text);
            //recept.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void ClearPrice()
        {
            txtCant.Text = "";
            txtTotalItem.Text = "";
            txtSubTotalItem.Text = "";
            txtIvaItem.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearPrice();
        }
    }
}
