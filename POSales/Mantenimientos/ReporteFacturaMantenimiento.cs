using Microsoft.Reporting.WinForms;
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

namespace POSales.Mantenimientos
{
    public partial class ReporteFacturaMantenimiento : Form
    {
        OrdenServicioModel orden = new OrdenServicioModel();
        Factura factura = new Factura();
        DBConnect dbcon = new DBConnect();
        public ReporteFacturaMantenimiento(Factura factura)
        {
            this.factura = factura;
            this.orden = orden;
            InitializeComponent();
            LoadRecept();
        }
        public void LoadRecept()
        {
            ReportDataSource rptDataSourece;
            this.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Reports\facturaMantenimiento.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();

            DataSet ds1 = new DataSet();
            ds1 = dbcon.generarReporteFactura(factura.id_venta);
            SqlDataAdapter da = new SqlDataAdapter();
            rptDataSourece = new ReportDataSource("DetallesDeCompra", ds1.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
            DataSet ds2 = new DataSet();
            ds2 = dbcon.selectFacturaIdData(factura.id_venta);
            rptDataSourece = new ReportDataSource("Factura", ds2.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
            DataSet ds3 = new DataSet();
            ds3 = dbcon.selectUsuariosDataPorId(factura.usuario);
            rptDataSourece = new ReportDataSource("Usuario", ds3.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
            DataSet ds4 = new DataSet();
            ds4 = dbcon.selectClienteIdData(factura.clienteId);
            rptDataSourece = new ReportDataSource("Cliente", ds4.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
            DataSet ds5 = new DataSet();
            ds5 = dbcon.selectTiendasDataId(1);
            rptDataSourece = new ReportDataSource("DetallesDeTienda", ds5.Tables[0]);
            reportViewer1.LocalReport.DataSources.Add(rptDataSourece);


            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;



        }
        private void ReporteFacturaMantenimiento_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }
    }
}
