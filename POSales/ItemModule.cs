
using POSalesDb;
using POSalesDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales
{
    public partial class ItemModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DBConnect dbcon = new DBConnect();
        string stitle = "Punto de venta";
        Items product;
        string imageLocation = string.Empty;
        bool Nuevo = false;
        public ItemModule(Items pd)
        {
            InitializeComponent();
            cn = new SqlConnection(dbcon.myConnection());
            LoadBrand();
            LoadCategory();
            LoadBodega();
            LoadGroup();
            product = pd;
            if (product.Id > 0)
            {
                CargarItem();
                btnSave.Visible = false;
            }
            else 
            {
                btnUpdate.Visible = false;
            }
        }
        private void CargarItem()
        {
            txtIdProd.Text = product.Id.ToString();
            txtNameProdcut.Text = product.nombre;
            txtCodUno.Text = product.codigoUno;
            txtCodDos.Text = product.codigoDos;
            txtCod3.Text = product.codigoTres;
            txtCod4.Text = product.codigoCuatro;
            txtBarcode.Text = product.codigoBarras;
            txtPriceA.Text = product.precioA.ToString();
            txtPriceB.Text = product.precioB.ToString();
            txtPriceC.Text = product.precioC.ToString();
            txtPriceD.Text = product.precioD.ToString();
            txtReason.Text = product.descripcion;
            txtPesoItem.Text = product.peso.ToString();
            txtComision.Text = product.comision.ToString();
            txtDescMax.Text = product.descMax.ToString();
            txtStockMax.Text = product.stockMax.ToString();
            txtStockMin.Text = product.stockMin.ToString();
            txtCosto.Text = product.costo.ToString();
            txtUnidad.Text = product.unidad.ToString();
            cboBodega.SelectedIndex =product.bId -1;
            cboCategory.SelectedIndex = product.cId -1;
            cboGroup.SelectedIndex = product.gId -1;
            cboBrand.SelectedIndex = product.mId -1;
            chckServicio.Checked = product.servicio;
            chckAplicaSeries.Checked = product.aplicaSeries;
            chckNegativo.Checked = product.negativo;
            chckCombo.Checked = product.combo;
            chkGasto.Checked = product.gasto;
            txtIce.Text = product.ice.ToString();
            txtValorIce.Text = product.valorIce.ToString();
            txtIva.Text = product.iva.ToString();
            HasIva.Checked = product.HasIva;
            txtCatA.Text = product.categoriaA;
            txtCatB.Text = product.categoriaB;
            txtCatC.Text = product.categoriaC;
            txtCatD.Text = product.categoriaD;
            txtCatE.Text = product.categoriaE;
            picItem.ImageLocation = product.imagen;


        }

        public void LoadCategory()
        {
            cboCategory.Items.Clear();
            cboCategory.DataSource = dbcon.getTable("SELECT * FROM Categorias");
            cboCategory.DisplayMember = "categoria";
            cboCategory.ValueMember = "id";
        }

        public void LoadBrand()
        {
            cboBrand.Items.Clear();
            cboBrand.DataSource = dbcon.getTable("SELECT * FROM Marcas");
            cboBrand.DisplayMember = "marca";
            cboBrand.ValueMember = "id";
        }

        public void LoadBodega()
        {
            cboBodega.Items.Clear();
            cboBodega.DataSource = dbcon.getTable("SELECT * FROM Bodega");
            cboBodega.DisplayMember = "nombre";
            cboBodega.ValueMember = "id";

        }
        public void LoadGroup() 
        {
            cboGroup.Items.Clear();
            cboGroup.DataSource = dbcon.getTable("SELECT * FROM Grupo");
            cboGroup.DisplayMember = "nombre";
            cboGroup.ValueMember = "Id";
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public void Clear()
        {
            txtIdProd.Clear();
            txtBarcode.Clear();
            //txtPdesc.Clear();
            txtPriceD.Clear();
            cboBrand.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
            //UDReOrder.Value = 1;
            
            txtIdProd.Enabled = false;
            txtIdProd.Focus();
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Nuevo)
            {
                product = new Items();
                CargarItem();
                Nuevo = false;
            }
            else
            {
                try
                {
                    if (MessageBox.Show("Estas seguro de guardar este Item?", "Item Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Items item = new Items();
                        MemoryStream ms = new MemoryStream();
                        byte[] data = System.IO.File.ReadAllBytes(Url);
                        picItem.Image.Save(ms, picItem.Image.RawFormat);
                        byte[] bytes = data;

                        decimal PrecioA = 0, PrecioB = 0, PrecioC = 0, PrecioD = 0;
                        item.nombre = txtNameProdcut.Text;
                         item.codigoUno = txtCodUno.Text;
                        item.codigoDos = txtCodDos.Text;
                        item.codigoTres = txtCod3.Text;
                        item.codigoCuatro = txtCod4.Text;
                        item.codigoBarras = txtCod3.Text;
                        item.codigoCuatro = txtCod4.Text;
                        decimal.TryParse(txtPriceA.Text, out PrecioA);
                        item.precioA = PrecioA;
                        decimal.TryParse(txtPriceB.Text, out PrecioB);
                        item.precioB = PrecioB;
                        decimal.TryParse(txtPriceC.Text, out PrecioC);
                        item.precioC = PrecioC;
                        decimal.TryParse(txtPriceD.Text, out PrecioD);
                        item.precioD = PrecioD;
                        item.descripcion = txtReason.Text;
                        item.unidadCaja = int.Parse(txtUnidadCaja.Text);
                        item.peso = decimal.Parse(txtPesoItem.Text);
                        item.comision = decimal.Parse(txtComision.Text);
                        item.descMax = decimal.Parse(txtDescMax.Text);
                        item.stockMax = int.Parse(txtStockMax.Text);
                        item.stockMin = int.Parse(txtStockMin.Text);
                        item.costo = decimal.Parse(txtCosto.Text);
                        item.unidad = int.Parse(txtUnidad.Text);
                        item.bId = cboBodega.SelectedIndex;
                        item.cId = cboCategory.SelectedIndex;
                        item.gId = cboGroup.SelectedIndex;
                        item.mId = cboBrand.SelectedIndex;
                        item.servicio = chckServicio.Checked;
                        item.aplicaSeries = chckAplicaSeries.Checked;
                        item.negativo = chckNegativo.Checked;
                        item.combo = chckCombo.Checked;
                        item.gasto = chkGasto.Checked;
                        item.ice = decimal.Parse(txtIce.Text);
                        item.valorIce = decimal.Parse(txtValorIce.Text);
                        item.HasIva = HasIva.Checked;
                        item.iva = decimal.Parse(txtIva.Text);
                        item.imagen = imageLocation;
                        item.imagenUrl = txtReason.Text;
                        item.montoTotal = decimal.Parse(txtPriceA.Text) * decimal.Parse(txtIva.Text);
                        item.categoriaA = txtCatA.Text;
                        item.categoriaB = txtCatB.Text;
                        item.categoriaC = txtCatC.Text;
                        item.categoriaD = txtCatD.Text;
                        item.categoriaE = txtCatE.Text;
                        MessageBox.Show("Item ingresado  con exito.", stitle);
                        DBConnect db = new DBConnect();
                        string Error = db.insertItem(item);
                        btnSave.Text = "Nuevo";
                        Nuevo = true;
                        btnUpdate.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
          
            Clear();    
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Items item = new Items();
            picBrowse.Visible = false;
            picItem.Enabled = false;
            MemoryStream ms = new MemoryStream();
            picItem.Visible = true;
            try
            {
                if (MessageBox.Show("Estas seguro de actualizar este Item?", "Actualizar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    decimal PrecioA = 0, PrecioB = 0, PrecioC = 0, PrecioD = 0;
                    item.nombre = txtNameProdcut.Text;
                    item.codigoUno = txtCodUno.Text;
                    item.codigoDos = txtCodDos.Text;
                    item.codigoTres = txtCod3.Text;
                    item.codigoCuatro = txtCod4.Text;
                    item.codigoBarras = txtCod3.Text;
                    item.codigoCuatro = txtCod4.Text;
                    decimal.TryParse(txtPriceA.Text, out PrecioA);
                    item.precioA = PrecioA;
                    decimal.TryParse(txtPriceB.Text, out PrecioB);
                    item.precioB = PrecioB;
                    decimal.TryParse(txtPriceC.Text, out PrecioC);
                    item.precioC = PrecioC;
                    decimal.TryParse(txtPriceD.Text, out PrecioD);
                    item.precioD = PrecioD;
                    item.descripcion= txtReason.Text;
                    item.unidadCaja= int.Parse(txtUnidadCaja.Text);
                    item.peso= decimal.Parse(txtPesoItem.Text);
                    item.comision= decimal.Parse(txtComision.Text);
                    item.descMax= decimal.Parse(txtDescMax.Text);
                    item.stockMax= int.Parse(txtStockMax.Text);
                    item.stockMin= int.Parse(txtStockMin.Text);
                    item.costo= decimal.Parse(txtCosto.Text);
                    item.unidad= int.Parse(txtUnidad.Text);
                    item.bId= cboBodega.SelectedIndex;
                    item.cId= cboCategory.SelectedIndex;
                    item.gId= cboGroup.SelectedIndex;
                    item.mId= cboBrand.SelectedIndex;
                    item.servicio= chckServicio.Checked;
                    item.aplicaSeries= chckAplicaSeries.Checked;
                    item.negativo= chckNegativo.Checked;
                    item.combo= chckCombo.Checked;
                    item.gasto= chkGasto.Checked;
                    item.ice= decimal.Parse(txtIce.Text);
                    item.valorIce= decimal.Parse(txtValorIce.Text);
                    item.HasIva= HasIva.Checked;
                    item.iva= decimal.Parse(txtIva.Text);
                    item.imagen= imageLocation;
                    item.imagenUrl= txtReason.Text;
                    item.montoTotal= decimal.Parse(txtPriceA.Text) * decimal.Parse(txtIva.Text);
                    item.categoriaA= txtCatA.Text;
                    item.categoriaB = txtCatB.Text;
                    item.categoriaC = txtCatC.Text;
                    item.categoriaD = txtCatD.Text;
                    item.categoriaE = txtCatE.Text;
                    DBConnect db = new DBConnect();
                   string Error = db.actualizarItem(item);
                    if (string.IsNullOrEmpty(Error))
                    {
                        MessageBox.Show("Item actualizado con exito.", stitle);
                    }
                    else 
                    {
                        MessageBox.Show(Error);
                    }
                }
                else
                {

                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void ProductModule_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void ProductModule_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Group module = new Group();
            module.ShowDialog();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            brand.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Bodega bodega = new Bodega();
            bodega.ShowDialog();
        }

        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPriceA_TextChanged(object sender, EventArgs e)
        {
<<<<<<< HEAD
            decimal iva = 0;
            if (HasIva.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtPriceA.Text))
                {
                    if (decimal.TryParse(txtPriceA.Text, out decimal price))
                    {
                        decimal.TryParse(txtIva.Text, out iva);
                        decimal calculo = price * (iva / 100);
                        valA.Text = calculo.ToString();
                    }
                }
            }

=======
            if (!string.IsNullOrEmpty(txtPriceA.Text))
            {
                if (decimal.TryParse(txtPriceA.Text, out decimal price))
                {
                    
                }
            }
>>>>>>> 5dead11c97c76d55a116ee29e6e8ab7f15cd0f82
        }
        string Url;
        private void picBrowse_Click(object sender, EventArgs e)
        {
            Url = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "seleciona la imagen (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picItem.Image = Image.FromFile(openFileDialog.FileName);
                Url = openFileDialog.FileName;
            }
        }

        private void txtPriceA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                // Allow Digits and BackSpace char
            }
            else if (e.KeyChar == '.' && !((TextBox)sender).Text.Contains(','))
            {
                e.KeyChar = ',';
            }
            else if (e.KeyChar == ',' && !((TextBox)sender).Text.Contains(','))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPriceB_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPriceC_TextChanged(object sender, EventArgs e)
        {
            decimal iva = 0;
            if (HasIva.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtPriceC.Text))
                {
                    if (decimal.TryParse(txtPriceC.Text, out decimal price))
                    {
                        decimal.TryParse(txtIva.Text, out iva);
                        decimal calculo = price * (iva / 100);
                        textBox25.Text = calculo.ToString();
                    }
                }
            }
        }

        private void txtPriceC_KeyPress(object sender, KeyPressEventArgs e)
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
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtPriceD_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIva_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtIce_KeyPress(object sender, KeyPressEventArgs e)
        {
               if(Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
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

        private void txtStockMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == '\b')
            {
                // Allow Digits and BackSpace char
            }
            else
            {
                e.Handled = true;
            }
        }

        private void HasIva_CheckedChanged(object sender, EventArgs e)
        {
            if (HasIva.Checked)
            {
                txtIva.Enabled = true;
                
            }
            else
            {
                txtIva.Enabled = false;
                txtIva.Text = "00,00";
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPriceB_TextChanged(object sender, EventArgs e)
        {
            decimal iva = 0;
            if (HasIva.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtPriceB.Text))
                {
                    if (decimal.TryParse(txtPriceB.Text, out decimal price))
                    {
                        decimal.TryParse(txtIva.Text, out iva);
                        decimal calculo = price * (iva / 100);
                        textBox24.Text = calculo.ToString();
                    }
                }
            }
        }

        private void txtPriceD_TextChanged(object sender, EventArgs e)
        {
            decimal iva = 0;
            if (HasIva.Checked == true)
            {
                if (!string.IsNullOrEmpty(txtPriceD.Text))
                {
                    if (decimal.TryParse(txtPriceD.Text, out decimal price))
                    {
                        decimal.TryParse(txtIva.Text, out iva);
                        decimal calculo = price * (iva / 100);
                        textBox26.Text = calculo.ToString();
                    }
                }
            }
        }
    }
}
