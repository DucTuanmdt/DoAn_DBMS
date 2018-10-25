namespace Quan_Ly_Kinh_Doanh
{
    partial class FormSanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSanPham));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimKiemTheoTentoolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.byIDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimKiemGiaNhoHontoolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.giáLớnHơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimKiemGiaLonHontoolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.dgvSANPHAM = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.btnLoadFileImg = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.pcbHinhAnh = new System.Windows.Forms.PictureBox();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDonViTinh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenSP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialogImg = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSANPHAM)).BeginInit();
            this.pnlHienThi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHinhAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.Beige;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reloadToolStripMenuItem,
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.cancelToolStripMenuItem,
            this.othersToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(777, 24);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.reload2;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.cancel;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem});
            this.othersToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.other2;
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.othersToolStripMenuItem.Text = "Others";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byNameToolStripMenuItem,
            this.byIDToolStripMenuItem,
            this.giáLớnHơnToolStripMenuItem});
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.findToolStripMenuItem.Text = "Tìm kiếm";
            // 
            // byNameToolStripMenuItem
            // 
            this.byNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimKiemTheoTentoolStripTextBox1});
            this.byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            this.byNameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.byNameToolStripMenuItem.Text = "Theo tên";
            // 
            // TimKiemTheoTentoolStripTextBox1
            // 
            this.TimKiemTheoTentoolStripTextBox1.Name = "TimKiemTheoTentoolStripTextBox1";
            this.TimKiemTheoTentoolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.TimKiemTheoTentoolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimKiemTheoTentoolStripTextBox1_KeyDown);
            // 
            // byIDToolStripMenuItem
            // 
            this.byIDToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimKiemGiaNhoHontoolStripTextBox1});
            this.byIDToolStripMenuItem.Name = "byIDToolStripMenuItem";
            this.byIDToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.byIDToolStripMenuItem.Text = "Giá nhỏ hơn";
            // 
            // TimKiemGiaNhoHontoolStripTextBox1
            // 
            this.TimKiemGiaNhoHontoolStripTextBox1.Name = "TimKiemGiaNhoHontoolStripTextBox1";
            this.TimKiemGiaNhoHontoolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.TimKiemGiaNhoHontoolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimKiemGiaNhoHontoolStripTextBox1_KeyDown);
            // 
            // giáLớnHơnToolStripMenuItem
            // 
            this.giáLớnHơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimKiemGiaLonHontoolStripTextBox2});
            this.giáLớnHơnToolStripMenuItem.Name = "giáLớnHơnToolStripMenuItem";
            this.giáLớnHơnToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.giáLớnHơnToolStripMenuItem.Text = "Giá lớn hơn";
            // 
            // TimKiemGiaLonHontoolStripTextBox2
            // 
            this.TimKiemGiaLonHontoolStripTextBox2.Name = "TimKiemGiaLonHontoolStripTextBox2";
            this.TimKiemGiaLonHontoolStripTextBox2.Size = new System.Drawing.Size(100, 23);
            this.TimKiemGiaLonHontoolStripTextBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimKiemGiaLonHontoolStripTextBox2_KeyDown);
            // 
            // dgvSANPHAM
            // 
            this.dgvSANPHAM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSANPHAM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSANPHAM.Location = new System.Drawing.Point(12, 146);
            this.dgvSANPHAM.Name = "dgvSANPHAM";
            this.dgvSANPHAM.Size = new System.Drawing.Size(605, 284);
            this.dgvSANPHAM.TabIndex = 1;
            this.dgvSANPHAM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSANPHAM_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã SP";
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(63, 15);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(100, 20);
            this.txtMaSP.TabIndex = 3;
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.Controls.Add(this.btnLoadFileImg);
            this.pnlHienThi.Controls.Add(this.label5);
            this.pnlHienThi.Controls.Add(this.pcbHinhAnh);
            this.pnlHienThi.Controls.Add(this.txtGiaBan);
            this.pnlHienThi.Controls.Add(this.label4);
            this.pnlHienThi.Controls.Add(this.txtDonViTinh);
            this.pnlHienThi.Controls.Add(this.label3);
            this.pnlHienThi.Controls.Add(this.txtTenSP);
            this.pnlHienThi.Controls.Add(this.label2);
            this.pnlHienThi.Controls.Add(this.txtMaSP);
            this.pnlHienThi.Controls.Add(this.label1);
            this.pnlHienThi.Location = new System.Drawing.Point(12, 27);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(605, 113);
            this.pnlHienThi.TabIndex = 4;
            // 
            // btnLoadFileImg
            // 
            this.btnLoadFileImg.Location = new System.Drawing.Point(439, 68);
            this.btnLoadFileImg.Name = "btnLoadFileImg";
            this.btnLoadFileImg.Size = new System.Drawing.Size(57, 23);
            this.btnLoadFileImg.TabIndex = 12;
            this.btnLoadFileImg.Text = "Thay đổi";
            this.btnLoadFileImg.UseVisualStyleBackColor = true;
            this.btnLoadFileImg.Click += new System.EventHandler(this.btnLoadFileImg_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(443, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Hình ảnh";
            // 
            // pcbHinhAnh
            // 
            this.pcbHinhAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcbHinhAnh.Location = new System.Drawing.Point(503, 3);
            this.pcbHinhAnh.Name = "pcbHinhAnh";
            this.pcbHinhAnh.Size = new System.Drawing.Size(100, 100);
            this.pcbHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pcbHinhAnh.TabIndex = 10;
            this.pcbHinhAnh.TabStop = false;
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(253, 68);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(148, 20);
            this.txtGiaBan.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(192, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Giá bán";
            // 
            // txtDonViTinh
            // 
            this.txtDonViTinh.Location = new System.Drawing.Point(63, 68);
            this.txtDonViTinh.Name = "txtDonViTinh";
            this.txtDonViTinh.Size = new System.Drawing.Size(100, 20);
            this.txtDonViTinh.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đơn vị tính";
            // 
            // txtTenSP
            // 
            this.txtTenSP.Location = new System.Drawing.Point(253, 15);
            this.txtTenSP.Name = "txtTenSP";
            this.txtTenSP.Size = new System.Drawing.Size(148, 20);
            this.txtTenSP.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(193, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên SP";
            // 
            // openFileDialogImg
            // 
            this.openFileDialogImg.FileName = "openFileDialogIMG";
            // 
            // FormSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(777, 442);
            this.Controls.Add(this.pnlHienThi);
            this.Controls.Add(this.dgvSANPHAM);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FormSanPham";
            this.Text = "Quản sản phẩm";
            this.Load += new System.EventHandler(this.FormSanPham_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSANPHAM)).EndInit();
            this.pnlHienThi.ResumeLayout(false);
            this.pnlHienThi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHinhAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem othersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byNameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byIDToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvSANPHAM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Panel pnlHienThi;
        private System.Windows.Forms.PictureBox pcbHinhAnh;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDonViTinh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenSP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadFileImg;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialogImg;
        private System.Windows.Forms.ToolStripTextBox TimKiemTheoTentoolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox TimKiemGiaNhoHontoolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem giáLớnHơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox TimKiemGiaLonHontoolStripTextBox2;
    }
}

