﻿using DevExpress.XtraReports.UI;
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
            XtraReport report = XtraReport.FromFile(@"..\\..\\Report11.repx", true);
            using (ReportPrintTool printTool = new ReportPrintTool(report))
            {
                printTool.PrintDialog();
                
                // Send the report to the default printer.
                printTool.Print();

                // Send the report to the specified printer.
                //printTool.Print("myPrinter");
            }
        }
    }
}
