using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSales
{
   
    public partial class MenuPrincipalFactura : Form
    {
        
        int idUser;
        public MenuPrincipalFactura(int _idUser, int _idCliente)
        {
            idUser = _idUser;
            InitializeComponent();
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            FacturaClientes factura = new FacturaClientes(idUser);
            factura.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picClientes_Click(object sender, EventArgs e)
        {
            Clients clientModule = new Clients();
            clientModule.ShowDialog();
           
        }

        private void MenuPrincipalFactura_Load(object sender, EventArgs e)
        {

        }
    }
}
