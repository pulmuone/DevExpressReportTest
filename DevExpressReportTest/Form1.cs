using DevExpress.XtraBars.Docking;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevExpressReportTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DataSetReport dsReport = new DataSetReport();
            DataRow dr;

            for (int i = 0; i < 10; i++)
            {
                dr = dsReport.Tables[0].NewRow();
                
                dr["BARCODE"] = "12345" + i.ToString();
                dr["PRODUCT_NAME"] ="상품이름 " + i.ToString();
                dr["CD_SIZE"] = "컬러 " + i.ToString();
                dr["CD_COLOR"] = "사이즈 " + i.ToString();

                dsReport.Tables[0].Rows.Add(dr);
            }

            XtraReport report = XtraReport.FromFile(@"..\\..\\Report11.repx", true);

            report.DataSource = dsReport;

            report.Parameters["orderDate"].Value = "2021-12-21";
            report.Parameters["whcd"].Value = "WH001";
            report.Parameters["orderType"].Value = "발주";
            report.Parameters["slipno"].Value = "1234567890";

            report.Parameters["orderDate"].Visible = false;
            report.Parameters["whcd"].Visible = false;
            report.Parameters["orderType"].Visible = false;
            report.Parameters["slipno"].Visible = false;

            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.PrintDialog();

                // Send the report to the default printer.
                printTool.Print();

                //printTool.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
                //Send the report to the specified printer.
                //printTool.Print("myPrinter");
            }
        }

        private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            e.PrintDocument.PrinterSettings.FromPage = 1;
            e.PrintDocument.PrinterSettings.ToPage = 10;
        }
    }
}
