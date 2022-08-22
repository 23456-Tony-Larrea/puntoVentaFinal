using System;
using System.Collections.Generic;
using System.Windows.Forms;
using POSalesDb;
using System.Linq;

namespace POSales.Mantenimientos
{
    public partial class EntregasCajero : Form
    {
        Usuarios usuario = new Usuarios();
        DBConnect dbcon = new DBConnect();
        List<OrdenServicioModel> ordenes = new List<OrdenServicioModel>();
        public EntregasCajero(int IdUsuario)
        {

            InitializeComponent();
            CargarOrdenes();
            usuario = dbcon.selectUsuariosPorId(IdUsuario);
        }
        private void CargarOrdenes()
        {
           
            ordenes = dbcon.selectTodosLasOrdenServicioModel();
            if (ordenes.Count > 0)
            {
                foreach (var orden in ordenes)
                {
                    decimal Total = 0;
                    foreach (var mantenimiento in orden.mantenimientos)
                    {
                        foreach (var reserva in mantenimiento.reservas)
                        {
                            Total += reserva.precioFinal;
                        }
                        Total += mantenimiento.precioReferencial;
                    }
                    dgvOrdenes.Rows.Add(orden.Id, orden.cliente.Id, orden.cliente.nombre, Total, orden.IsReady);
                }
            }
            
        }

        private void btnBuscarCodigo_Click(object sender, EventArgs e)
        {

        }

        private void EntregasCajero_Load(object sender, EventArgs e)
        {

        }

        private void enviarSolucionPorWhatsappToolStripMenuItem_Click(object sender, EventArgs e)
        {
            


        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void noSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
