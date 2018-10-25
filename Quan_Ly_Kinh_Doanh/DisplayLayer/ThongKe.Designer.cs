namespace Quan_Ly_Kinh_Doanh
{
    partial class ThongKe
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnReload = new System.Windows.Forms.Button();
            this.search_NV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTenNV = new System.Windows.Forms.ComboBox();
            this.reportViewerNV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnReload2 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbbHoaDon = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewerHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnXem = new System.Windows.Forms.Button();
            this.cbbMaHD = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.reportViewerCTHD = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_XEM = new System.Windows.Forms.Button();
            this.cbbNV = new System.Windows.Forms.ComboBox();
            this.reportViewerCTNV = new Microsoft.Reporting.WinForms.ReportViewer();
            this.NHANVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QLST = new Quan_Ly_Kinh_Doanh.QLST();
            this.CHITIETHOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.HOADONBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TTNVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.NHANVIENTableAdapter = new Quan_Ly_Kinh_Doanh.QLSTTableAdapters.NHANVIENTableAdapter();
            this.CHITIETHOADONTableAdapter = new Quan_Ly_Kinh_Doanh.QLSTTableAdapters.CHITIETHOADONTableAdapter();
            this.HOADONTableAdapter = new Quan_Ly_Kinh_Doanh.QLSTTableAdapters.HOADONTableAdapter();
            this.TTNVTableAdapter = new Quan_Ly_Kinh_Doanh.QLSTTableAdapters.TTNVTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NHANVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLST)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHITIETHOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TTNVBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 3);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(944, 466);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnReload);
            this.tabPage1.Controls.Add(this.search_NV);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.cbbTenNV);
            this.tabPage1.Controls.Add(this.reportViewerNV);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(936, 440);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Nhân Viên";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(368, 37);
            this.btnReload.Margin = new System.Windows.Forms.Padding(2);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(81, 20);
            this.btnReload.TabIndex = 3;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // search_NV
            // 
            this.search_NV.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_NV.Location = new System.Drawing.Point(269, 37);
            this.search_NV.Margin = new System.Windows.Forms.Padding(2);
            this.search_NV.Name = "search_NV";
            this.search_NV.Size = new System.Drawing.Size(81, 20);
            this.search_NV.TabIndex = 3;
            this.search_NV.Text = "Tìm kiếm";
            this.search_NV.UseVisualStyleBackColor = true;
            this.search_NV.Click += new System.EventHandler(this.search_NV_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên NV";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tìm kiếm";
            // 
            // cbbTenNV
            // 
            this.cbbTenNV.FormattingEnabled = true;
            this.cbbTenNV.Location = new System.Drawing.Point(97, 38);
            this.cbbTenNV.Margin = new System.Windows.Forms.Padding(2);
            this.cbbTenNV.Name = "cbbTenNV";
            this.cbbTenNV.Size = new System.Drawing.Size(158, 21);
            this.cbbTenNV.TabIndex = 1;
            // 
            // reportViewerNV
            // 
            reportDataSource1.Name = "Report_NV";
            reportDataSource1.Value = this.NHANVIENBindingSource;
            this.reportViewerNV.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewerNV.LocalReport.ReportEmbeddedResource = "Quan_Ly_Kinh_Doanh.Report1.rdlc";
            this.reportViewerNV.LocalReport.ReportPath = "Report1.rdlc";
            this.reportViewerNV.Location = new System.Drawing.Point(4, 81);
            this.reportViewerNV.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewerNV.Name = "reportViewerNV";
            this.reportViewerNV.Size = new System.Drawing.Size(790, 357);
            this.reportViewerNV.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnReload2);
            this.tabPage2.Controls.Add(this.btnOK);
            this.tabPage2.Controls.Add(this.cbbHoaDon);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.reportViewerHD);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(936, 440);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hóa Đơn";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnReload2
            // 
            this.btnReload2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload2.Location = new System.Drawing.Point(418, 13);
            this.btnReload2.Margin = new System.Windows.Forms.Padding(2);
            this.btnReload2.Name = "btnReload2";
            this.btnReload2.Size = new System.Drawing.Size(81, 20);
            this.btnReload2.TabIndex = 6;
            this.btnReload2.Text = "Reload";
            this.btnReload2.UseVisualStyleBackColor = true;
            this.btnReload2.Click += new System.EventHandler(this.btnReload2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(307, 13);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 20);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbbHoaDon
            // 
            this.cbbHoaDon.FormattingEnabled = true;
            this.cbbHoaDon.Location = new System.Drawing.Point(130, 13);
            this.cbbHoaDon.Margin = new System.Windows.Forms.Padding(2);
            this.cbbHoaDon.Name = "cbbHoaDon";
            this.cbbHoaDon.Size = new System.Drawing.Size(158, 21);
            this.cbbHoaDon.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Chi tiết hóa đơn";
            // 
            // reportViewerHD
            // 
            reportDataSource2.Name = "Report_HD";
            reportDataSource2.Value = this.CHITIETHOADONBindingSource;
            this.reportViewerHD.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewerHD.LocalReport.ReportEmbeddedResource = "Quan_Ly_Kinh_Doanh.Report2.rdlc";
            this.reportViewerHD.LocalReport.ReportPath = "Report2.rdlc";
            this.reportViewerHD.Location = new System.Drawing.Point(2, 73);
            this.reportViewerHD.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewerHD.Name = "reportViewerHD";
            this.reportViewerHD.Size = new System.Drawing.Size(790, 303);
            this.reportViewerHD.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnXem);
            this.tabPage3.Controls.Add(this.cbbMaHD);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.reportViewerCTHD);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(936, 440);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Chi Tiết Hóa Đơn";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(264, 14);
            this.btnXem.Margin = new System.Windows.Forms.Padding(2);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(89, 20);
            this.btnXem.TabIndex = 3;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // cbbMaHD
            // 
            this.cbbMaHD.FormattingEnabled = true;
            this.cbbMaHD.Location = new System.Drawing.Point(98, 15);
            this.cbbMaHD.Margin = new System.Windows.Forms.Padding(2);
            this.cbbMaHD.Name = "cbbMaHD";
            this.cbbMaHD.Size = new System.Drawing.Size(149, 21);
            this.cbbMaHD.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 14);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hóa Đơn";
            // 
            // reportViewerCTHD
            // 
            reportDataSource3.Name = "Report_CTHD";
            reportDataSource3.Value = this.HOADONBindingSource;
            this.reportViewerCTHD.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewerCTHD.LocalReport.ReportEmbeddedResource = "Quan_Ly_Kinh_Doanh.Report3.rdlc";
            this.reportViewerCTHD.LocalReport.ReportPath = "Report3.rdlc";
            this.reportViewerCTHD.Location = new System.Drawing.Point(2, 48);
            this.reportViewerCTHD.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewerCTHD.Name = "reportViewerCTHD";
            this.reportViewerCTHD.Size = new System.Drawing.Size(931, 390);
            this.reportViewerCTHD.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btn_XEM);
            this.tabPage4.Controls.Add(this.cbbNV);
            this.tabPage4.Controls.Add(this.reportViewerCTNV);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage4.Size = new System.Drawing.Size(936, 440);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Thông tin NV";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_XEM
            // 
            this.btn_XEM.Location = new System.Drawing.Point(221, 5);
            this.btn_XEM.Margin = new System.Windows.Forms.Padding(2);
            this.btn_XEM.Name = "btn_XEM";
            this.btn_XEM.Size = new System.Drawing.Size(57, 23);
            this.btn_XEM.TabIndex = 2;
            this.btn_XEM.Text = "Xem";
            this.btn_XEM.UseVisualStyleBackColor = true;
            this.btn_XEM.Click += new System.EventHandler(this.btn_XEM_Click);
            // 
            // cbbNV
            // 
            this.cbbNV.FormattingEnabled = true;
            this.cbbNV.Location = new System.Drawing.Point(31, 8);
            this.cbbNV.Margin = new System.Windows.Forms.Padding(2);
            this.cbbNV.Name = "cbbNV";
            this.cbbNV.Size = new System.Drawing.Size(165, 21);
            this.cbbNV.TabIndex = 1;
            // 
            // reportViewerCTNV
            // 
            reportDataSource4.Name = "Report_TTNV";
            reportDataSource4.Value = this.TTNVBindingSource;
            this.reportViewerCTNV.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewerCTNV.LocalReport.ReportEmbeddedResource = "Quan_Ly_Kinh_Doanh.Report4.rdlc";
            this.reportViewerCTNV.LocalReport.ReportPath = "Report4.rdlc";
            this.reportViewerCTNV.Location = new System.Drawing.Point(2, 50);
            this.reportViewerCTNV.Margin = new System.Windows.Forms.Padding(2);
            this.reportViewerCTNV.Name = "reportViewerCTNV";
            this.reportViewerCTNV.Size = new System.Drawing.Size(931, 383);
            this.reportViewerCTNV.TabIndex = 0;
            // 
            // NHANVIENBindingSource
            // 
            this.NHANVIENBindingSource.DataMember = "NHANVIEN";
            this.NHANVIENBindingSource.DataSource = this.QLST;
            // 
            // QLST
            // 
            this.QLST.DataSetName = "QLST";
            this.QLST.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // CHITIETHOADONBindingSource
            // 
            this.CHITIETHOADONBindingSource.DataMember = "CHITIETHOADON";
            this.CHITIETHOADONBindingSource.DataSource = this.QLST;
            // 
            // HOADONBindingSource
            // 
            this.HOADONBindingSource.DataMember = "HOADON";
            this.HOADONBindingSource.DataSource = this.QLST;
            // 
            // TTNVBindingSource
            // 
            this.TTNVBindingSource.DataMember = "TTNV";
            this.TTNVBindingSource.DataSource = this.QLST;
            // 
            // NHANVIENTableAdapter
            // 
            this.NHANVIENTableAdapter.ClearBeforeFill = true;
            // 
            // CHITIETHOADONTableAdapter
            // 
            this.CHITIETHOADONTableAdapter.ClearBeforeFill = true;
            // 
            // HOADONTableAdapter
            // 
            this.HOADONTableAdapter.ClearBeforeFill = true;
            // 
            // TTNVTableAdapter
            // 
            this.TTNVTableAdapter.ClearBeforeFill = true;
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 473);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ThongKe";
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NHANVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QLST)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CHITIETHOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HOADONBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TTNVBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource NHANVIENBindingSource;
        private QLST QLST;
        private QLSTTableAdapters.NHANVIENTableAdapter NHANVIENTableAdapter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerNV;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbTenNV;
        private System.Windows.Forms.Button search_NV;
        private System.Windows.Forms.Button btnReload;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerHD;
        private System.Windows.Forms.BindingSource CHITIETHOADONBindingSource;
        private QLSTTableAdapters.CHITIETHOADONTableAdapter CHITIETHOADONTableAdapter;
        private System.Windows.Forms.Button btnReload2;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbbHoaDon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPage3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCTHD;
        private System.Windows.Forms.BindingSource HOADONBindingSource;
        private QLSTTableAdapters.HOADONTableAdapter HOADONTableAdapter;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.ComboBox cbbMaHD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage4;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerCTNV;
        private System.Windows.Forms.BindingSource TTNVBindingSource;
        private QLSTTableAdapters.TTNVTableAdapter TTNVTableAdapter;
        private System.Windows.Forms.Button btn_XEM;
        private System.Windows.Forms.ComboBox cbbNV;
    }
}

