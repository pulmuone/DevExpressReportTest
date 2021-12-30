using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Control;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraReports.UI;
using DevExpressReportTest.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsApp5.Printer;

namespace DevExpressReportTest
{
    public partial class Form1 : Form
    {
        DataSetReport dsReport = new DataSetReport();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            DataRow dr;

            dr = dsReport.Tables[0].NewRow();
            dr["BARCODE"] = "11111";
            dr["PRODUCT_NAME"] = "상품이름1";
            dr["CD_SIZE"] = "컬러1";
            dr["CD_COLOR"] = "사이즈1";
            dsReport.Tables[0].Rows.Add(dr);

            dr = dsReport.Tables[0].NewRow();
            dr["BARCODE"] = "11111";
            dr["PRODUCT_NAME"] = "상품이름2";
            dr["CD_SIZE"] = "컬러2";
            dr["CD_COLOR"] = "사이즈2";
            dsReport.Tables[0].Rows.Add(dr);

            dr = dsReport.Tables[0].NewRow();
            dr["BARCODE"] = "22222";
            dr["PRODUCT_NAME"] = "상품이름3";
            dr["CD_SIZE"] = "컬러3";
            dr["CD_COLOR"] = "사이즈3";
            dsReport.Tables[0].Rows.Add(dr);

            //for (int i = 0; i < 10; i++)
            //{
            //    dr = dsReport.Tables[0].NewRow();

            //    dr["BARCODE"] = "12345" + i.ToString();
            //    dr["PRODUCT_NAME"] ="상품이름 " + i.ToString();
            //    dr["CD_SIZE"] = "컬러 " + i.ToString();
            //    dr["CD_COLOR"] = "사이즈 " + i.ToString();

            //    dsReport.Tables[0].Rows.Add(dr);
            //}

            //XtraReport report = XtraReport.FromFile("Report11.repx", true);
            XtraReport report = XtraReport.FromFile(Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "Report52.repx"), true);
            //XtraReport report = new XtraReport();
            //report.LoadLayout(@"..\\..\\Report11.repx");
            //report.LoadLayout(@"Report11.repx");

            //XRSubreport subReport = new XRSubreport();
            //subReport.ReportSourceUrl  = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "ReportSub.repx");

            //subReport.BeforePrint += SubReport_BeforePrint;

            //report.DataSource = dsReport;

            report.Parameters["orderDate"].Value = "2021-12-21";
            //report.Parameters["whcd"].Value = "WH001";
            //report.Parameters["orderType"].Value = "발주";
            //report.Parameters["slipno"].Value = "1234567890";

            //report.Parameters["orderDate"].Visible = false;
            //report.Parameters["whcd"].Visible = false;
            //report.Parameters["orderType"].Visible = false;
            //report.Parameters["slipno"].Visible = false;


            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                //printTool.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
                //printTool.PrintingSystem.PrintProgress += new PrintProgressEventHandler(PrintingSystem_PrintProgress);
                //printTool.PrintingSystem.EndPrint += new EventHandler(PrintingSystem_EndPrint);

                //printTool.PrintDialog();

                // Send the report to the default printer.
                //printTool.Print();

                //printTool.PrintingSystem.StartPrint += PrintingSystem_StartPrint;
                //Send the report to the specified printer.
                printTool.Print(this.textBox1.Text); //프린터 지정해서 바로 인쇄, OneNote 16으로 보내기
            }
        }

        private void SubReport_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((XRSubreport)sender).ReportSource.DataSource = dsReport;
            ((XRSubreport)sender).ReportSource.DataMember = "DataTableReport";
        }

        private void PrintingSystem_EndPrint(object sender, EventArgs e)
        {
            Debug.WriteLine("프린터 종료");
        }

        private void PrintingSystem_PrintProgress(object sender, PrintProgressEventArgs e)
        {
            Debug.WriteLine(string.Format("{0} : {1}", "프린터 인쇄 중", e.PageIndex));
            Console.WriteLine(e.PrintAction);
        }

        private void Report_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            //e.PrintDocument.PrinterSettings.FromPage = 1;
            //e.PrintDocument.PrinterSettings.ToPage = 10;

            //prnSettings = e.PrintDocument.PrinterSettings;
            Debug.WriteLine("프린터 시작");
        }

        private void btnPrinterSelect_Click(object sender, EventArgs e)
        {
            PrinterSelect printerSelect = new PrinterSelect();
            printerSelect.PrinaterSelectEvent += PrinterName;

            printerSelect.ShowDialog();
        }

        private void PrinterName(string printerName)
        {
            this.textBox1.Text = printerName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = Settings.Default.PrinterName;
            this.textBox2.Text = Path.GetDirectoryName(typeof(Program).Assembly.Location);
        }

        private void btnSubReport_Click(object sender, EventArgs e)
        {

            DataRow dr;

            for (int i = 0; i < 10; i++)
            {
                dr = dsReport.Tables[0].NewRow();
                dr["BARCODE"] = "11111" + i.ToString();
                dr["PRODUCT_NAME"] = "상품이름" + i.ToString();
                dr["CD_SIZE"] = "컬러" + i.ToString();
                dr["CD_COLOR"] = "사이즈" + i.ToString();
                dsReport.Tables[0].Rows.Add(dr);
            }


            XtraReport report = XtraReport.FromFile(Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "Report11.repx"), true);
            XtraReport subreport = XtraReport.FromFile(Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "ReportSub.repx"), true);

            
            report.CreateDocument(true);
            subreport.CreateDocument(true);

            subreport.RequestParameters = false;
            report.PrintingSystem.ShowMarginsWarning = false;
            report.PrintingSystem.ShowPrintStatusDialog = false;
            report.ShowPrintStatusDialog = false;
            report.ShowPrintMarginsWarning = false;            

            subreport.PrintingSystem.ShowMarginsWarning = false;
            subreport.PrintingSystem.ShowPrintStatusDialog = false;
            subreport.ShowPrintStatusDialog = false;
            subreport.ShowPrintMarginsWarning = false;
            subreport.PrintOnEmptyDataSource = false; //서브 리포트에 데이터가 없으면 인쇄하지 않기

            report.Parameters["orderDate"].Value = "2021-12-21";
            report.Parameters["whcd"].Value = "WH001";
            report.Parameters["orderType"].Value = "발주";
            report.Parameters["slipno"].Value = "1234567890";
            subreport.Parameters["parameter1"].Value = 3;

            ((XRSubreport)report.FindControl("subreport1", true)).ReportSource = subreport;
            //((XRSubreport)report.FindControl("subreport1", true)).ReportSourceUrl = ""; //경로를 직접 지정 하는 방식
            ((XRSubreport)report.FindControl("subreport1", true)).BeforePrint += new System.Drawing.Printing.PrintEventHandler(Form1_BeforePrint);

            subreport.XmlDataPath = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "DataSetReport.xsd");
            subreport.DataSource = dsReport;
            
            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.Print(this.textBox1.Text); //프린터 지정해서 바로 인쇄
            }

            //report를 직접 Print하는 것과 ReportPrintTool로 하는것의 차이점
            //report.Print(this.textBox1.Text); //프린터 지정해서 바로 인쇄
        }

        /// <summary>
        /// 서브 리포트에 데이터 전달
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRSubreport xrSubReport = (XRSubreport)sender;
            xrSubReport.ReportSource.Parameters["parameter1"].Value = 3;

            //DetailReport subRep = xrSubReport.ReportSource as DetailReport;
            //subRep.Parameters["CatID"].Value = Convert.ToInt32(GetCurrentColumnValue("CategoryID"));
            //((XRSubreport)sender).ReportSource.DataSource = dsReport;
            //((XRSubreport)sender).ReportSource.FilterString = "[CategoryID] = " + Convert.ToInt32(((XRSubreport)sender).Report.GetCurrentColumnValue("CategoryID")).ToString();
        }
    }
}
