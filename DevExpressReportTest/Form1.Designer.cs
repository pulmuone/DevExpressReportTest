
namespace DevExpressReportTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrinterSelect = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnSubReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(30, 106);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(132, 61);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "출력";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrinterSelect
            // 
            this.btnPrinterSelect.Location = new System.Drawing.Point(211, 106);
            this.btnPrinterSelect.Name = "btnPrinterSelect";
            this.btnPrinterSelect.Size = new System.Drawing.Size(107, 61);
            this.btnPrinterSelect.TabIndex = 1;
            this.btnPrinterSelect.Text = "프린터 선택";
            this.btnPrinterSelect.UseVisualStyleBackColor = true;
            this.btnPrinterSelect.Click += new System.EventHandler(this.btnPrinterSelect_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(522, 21);
            this.textBox1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(8, 249);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(791, 374);
            this.panel1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(29, 57);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(522, 21);
            this.textBox2.TabIndex = 5;
            // 
            // btnSubReport
            // 
            this.btnSubReport.Location = new System.Drawing.Point(459, 106);
            this.btnSubReport.Name = "btnSubReport";
            this.btnSubReport.Size = new System.Drawing.Size(111, 61);
            this.btnSubReport.TabIndex = 6;
            this.btnSubReport.Text = "서브리포트";
            this.btnSubReport.UseVisualStyleBackColor = true;
            this.btnSubReport.Click += new System.EventHandler(this.btnSubReport_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 633);
            this.Controls.Add(this.btnSubReport);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnPrinterSelect);
            this.Controls.Add(this.btnPrint);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPrinterSelect;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnSubReport;
    }
}

