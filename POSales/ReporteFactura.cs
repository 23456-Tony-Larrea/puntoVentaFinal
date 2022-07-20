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

namespace POSales
{
    public partial class ReporteFactura : Form
    {

        POSalesDb.Compras compra = new POSalesDb.Compras();
        DBConnect dbcon = new DBConnect();
        public ReporteFactura(POSalesDb.Compras compra)
        {
            InitializeComponent();
            this.compra = compra;
            LoadRecept();
        }

        public void LoadRecept()
        {
            ReportDataSource rptDataSourece;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\J_Bra\source\PuntoDeVenta\puntoVentaFinal\POSales\Report1.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear(); 

                DataSet ds1 = new DataSet();
                ds1 = dbcon.generarReporte(compra.Id);
                SqlDataAdapter da = new SqlDataAdapter();
                rptDataSourece = new ReportDataSource("DetallesDeCompra", ds1.Tables[0]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
                DataSet ds2 = new DataSet();
                ds2 = dbcon.selectComprasDataPorId(compra.Id);
                rptDataSourece = new ReportDataSource("CompraObjecty", ds2.Tables[0]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
                DataSet ds3 = new DataSet();
                ds3 = dbcon.selectUsuariosDataPorId(compra.idUsuario);
                rptDataSourece = new ReportDataSource("Usuario", ds3.Tables[0]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
                DataSet ds4 = new DataSet();
                ds4 = dbcon.selectProveedorDataPorId(compra.idProveedor);
                rptDataSourece = new ReportDataSource("Proveedor", ds4.Tables[0]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSourece);
                DataSet ds5 = new DataSet();
                ds5 = dbcon.selectTiendasDataId(1);
                rptDataSourece = new ReportDataSource("DetallesDeTienda", ds5.Tables[0]);
                reportViewer1.LocalReport.DataSources.Add(rptDataSourece);


            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;



        }

        private void ReporteFactura_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
