
using POSalesDb;
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
           
            int Categoria = 0, grupo = 0, brand = 0, bogeda = 0;
            txtIdProd.Text = product.Id.ToString();
            txtNameProdcut.Text = product.nombre;
            txtBarcode.Text = product.codigoBarras;
            txtPriceA.Text = product.precioA.ToString();
            txtPriceB.Text = product.precioB.ToString();
            txtPriceC.Text = product.precioC.ToString();
            txtPriceD.Text = product.precioD.ToString();
            txtReason.Text = product.descripcion;
           
            txtStockMax.Text = product.stock.ToString();
            txtStockMin.Text = product.stockMin.ToString();
            int.TryParse(product.bId.ToString(),out  bogeda);
            int.TryParse(product.cId.ToString(), out Categoria);
            int.TryParse(product.gId.ToString(), out grupo);
            int.TryParse(product.bId.ToString(), out brand);
            if (bogeda > 0)
            {
                cboBodega.SelectedIndex = bogeda - 1;
            }
            if (Categoria > 0)
            {
                cboCategory.SelectedIndex = Categoria - 1;
            }
            if(grupo > 0)
            {
                cboGroup.SelectedIndex = grupo - 1;
            }


            if (brand > 0)
            {
                cboBrand.SelectedIndex = brand - 1;
            }
        
            chckServicio.Checked = product.servicio;
            chckAplicaSeries.Checked = product.aplicaSeries;
            chckNegativo.Checked = product.negativo;
            chckCombo.Checked = product.hascombo;
            txtIce.Text = product.ice.ToString();
            txtValorIce.Text = product.valorIce.ToString();
            txtIva.Text = product.iva.ToString();
            HasIva.Checked = product.HasIva;
            picItem.Image = Image.FromFile(dbcon.selectItemImagenUrl(product.Id));
            
            if (product.hascombo)
            {
                product.Combo = dbcon.selectCombo(product.Id);
                dgvCombo.DataSource = product.Combo;
            }

        }
        public void LoadCombos()
        {
            //CARGAR COMBOS
            dgvCombo.DataSource = new DataTable();
            dgvCombo.DataSource = dbcon.selectCombo(product.Id);
        }


        public void LoadCategory()
        {
            cboCategory.DataSource = new DataTable();
            cboCategory.DataSource = dbcon.getTable("SELECT * FROM Categorias");
            cboCategory.DisplayMember = "categoria";
            cboCategory.ValueMember = "id";
        }

        public void LoadBrand()
        {
            cboBrand.DataSource = new DataTable();
            cboBrand.DataSource = dbcon.getTable("SELECT * FROM Marcas");
            cboBrand.DisplayMember = "marca";
            cboBrand.ValueMember = "id";
        }

        public void LoadBodega()
        {
            cboBodega.DataSource = new DataTable();
            cboBodega.DataSource = dbcon.getTable("SELECT * FROM Bodega");
            cboBodega.DisplayMember = "nombre";
            cboBodega.ValueMember = "id";

        }
        public void LoadGroup() 
        {
            cboGroup.DataSource = new DataTable();
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
                        if (string.IsNullOrEmpty(txtBarcode.Text))
                        {
                            MessageBox.Show("Por favor, ingrese el codigo de barra");
                        }
                        Items item = new Items();
                        decimal PrecioA = 0, PrecioB = 0, PrecioC = 0, PrecioD = 0;
                        item.nombre = txtNameProdcut.Text;
                        decimal.TryParse(txtPriceA.Text, out PrecioA);
                        item.precioA = PrecioA;
                        decimal.TryParse(txtPriceB.Text, out PrecioB);
                        item.precioB = PrecioB;
                        decimal.TryParse(txtPriceC.Text, out PrecioC);
                        item.precioC = PrecioC;
                        decimal.TryParse(txtPriceD.Text, out PrecioD);
                        item.codigoBarras = txtBarcode.Text;
                        item.precioD = PrecioD;
                        item.descripcion = txtReason.Text;
                     
                        item.stock = int.Parse(txtStockMax.Text);
                        item.stockMin = int.Parse(txtStockMin.Text);
                        item.bId = cboBodega.SelectedIndex;
                        item.cId = cboCategory.SelectedIndex;
                        item.gId = cboGroup.SelectedIndex;
                        item.mId = cboBrand.SelectedIndex;
                        item.servicio = chckServicio.Checked;
                        item.aplicaSeries = chckAplicaSeries.Checked;
                        item.negativo = chckNegativo.Checked;
                        item.hascombo = chckCombo.Checked;
                        item.ice = decimal.Parse(txtIce.Text);
                        item.valorIce = decimal.Parse(txtValorIce.Text);
                        item.HasIva = HasIva.Checked;
                        item.iva = decimal.Parse(txtIva.Text);
                        if (File.Exists(imageLocation))
                        {
                            item.imagen = (Bitmap)Image.FromFile(imageLocation);
                        }
                        else
                        {
                            item.imagen = (Bitmap)Image.FromFile($@"{Directory.GetCurrentDirectory()}\Image\cancel_30px.png");
                        }
                        item.imagenUrl = txtReason.Text;
                        item.montoTotal = decimal.Parse(txtPriceA.Text) * decimal.Parse(txtIva.Text);
                     
                        DBConnect db = new DBConnect();
                        int Error = db.insertItem(item);
                        if (Error > 0)
                        {
                            MessageBox.Show("Item ingresado  con exito.", stitle);
                        }
                        else
                        {
                            MessageBox.Show("Ha ocurrido un error al insertar los datos", stitle);
                        }
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
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            picBrowse.Visible = false;
            picItem.Enabled = false;
            MemoryStream ms = new MemoryStream();

            picItem.Visible = true;
            try
            {
                if (MessageBox.Show("Estas seguro de actualizar este Item?", "Actualizar producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrEmpty(txtBarcode.Text))
                    {
                        MessageBox.Show("Por favor, ingrese el codigo de barra");
                    }
                    decimal PrecioA = 0, PrecioB = 0, PrecioC = 0, PrecioD = 0;
                    product.nombre = txtNameProdcut.Text;
                    decimal.TryParse(txtPriceA.Text, out PrecioA);
                    product.precioA = PrecioA;
                    decimal.TryParse(txtPriceB.Text, out PrecioB);
                    product.precioB = PrecioB;
                    decimal.TryParse(txtPriceC.Text, out PrecioC);
                    product.precioC = PrecioC;
                    decimal.TryParse(txtPriceD.Text, out PrecioD);
                    product.codigoBarras = txtBarcode.Text;
                    product.precioD = PrecioD;
                    product.descripcion= txtReason.Text;
             
                    product.stock= int.Parse(txtStockMax.Text);
                    product.stockMin= int.Parse(txtStockMin.Text);
                    product.bId= cboBodega.SelectedIndex;
                    product.cId= cboCategory.SelectedIndex;
                    product.gId= cboGroup.SelectedIndex;
                    product.mId= cboBrand.SelectedIndex;
                    product.servicio= chckServicio.Checked;
                    product.aplicaSeries= chckAplicaSeries.Checked;
                    product.negativo= chckNegativo.Checked;
                    product.hascombo= chckCombo.Checked;
                    product.ice= decimal.Parse(txtIce.Text);
                    product.valorIce= decimal.Parse(txtValorIce.Text);
                    product.HasIva= HasIva.Checked;
                    product.iva= decimal.Parse(txtIva.Text);
                    product.imagenUrl = imageLocation;
                    if (File.Exists(imageLocation))
                    {
                        product.imagen = (Bitmap)Image.FromFile(imageLocation);
                    }
                    else
                    {
                        product.imagen = (Bitmap)Image.FromFile($@"{Directory.GetCurrentDirectory()}\Image\cancel_30px.png");
                    }

                    product.montoTotal= decimal.Parse(txtPriceA.Text) * decimal.Parse(txtIva.Text);
                    DBConnect db = new DBConnect();
                   string Error = db.actualizarItem(product);
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
            LoadCategory();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Brand brand = new Brand();
            brand.ShowDialog();
            LoadBrand();


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.ShowDialog();
            LoadCategory();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Bodega bodega = new Bodega();
            bodega.ShowDialog();
            LoadBodega();
        }

        private void CalcularIvaPrecioA()
        { 
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
        }
        private void cboBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcularIvaPrecioA();
        }

        private void txtPriceA_TextChanged(object sender, EventArgs e)
        {
            

        }
        string Url;
        private void picBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "seleciona la imagen (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                picItem.Image = Image.FromFile(openFileDialog.FileName);
                imageLocation = openFileDialog.FileName;
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
            CalcularIvaPrecioC();
        }

        private void CalcularIvaPrecioC()
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
            CalcularIvaPrecioB();
        }

        private void CalcularIvaPrecioB()
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
            CalcularIvaPrecioD();
        }

        private void CalcularIvaPrecioD()
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

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (product.Id > 0)
            {
                Form Combo = new combo(product.Id);
                Combo.ShowDialog();
                LoadCombos();
            }
            else
            {
                MessageBox.Show("Por favor, primero guarde el item antes de asignarle un combo");
            }
    
        }

        private void chckCombo_CheckedChanged(object sender, EventArgs e)
        {
            if (chckCombo.Checked)
            {
                btnAgregarCombos.Enabled = true;
                dgvCombo.Enabled = true;
            }
            
        }

        private void dgvCombo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Items items = new Items();

            foreach (var combo in items.Combo)
            {
                dgvCombo.Rows.Add(combo.Id, combo.nombre, combo.categoria.nombre, combo.marcas.Nombre, combo.grupo.nombre, combo.Bodega.Nombre);

            }
            id.Visible = true;

            string Error = string.Empty;
            int IdProductoRelacionado = 0;
            string colName = dgvCombo.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (int.TryParse(dgvCombo.Rows[e.RowIndex].Cells["IdData"].Value.ToString(), out IdProductoRelacionado))
                {
                    Error = dbcon.deleteCombo(product.Id, IdProductoRelacionado);
                    if (string.IsNullOrEmpty(Error))
                    {
                        product.Combo.RemoveAt(e.RowIndex);
                        dgvCombo.DataSource = new List<Items>();

                        dgvCombo.DataSource = product.Combo;
                        MessageBox.Show("Borrado Satisfactoriamente");
                    }
                    else
                    {
                        MessageBox.Show(Error);
                    }
                }

            }
        }

        private void txtIva_TextChanged(object sender, EventArgs e)
        {
            CalcularIvaPrecioA();
            CalcularIvaPrecioB();
            CalcularIvaPrecioC();
            CalcularIvaPrecioD();
        }

    }
}
