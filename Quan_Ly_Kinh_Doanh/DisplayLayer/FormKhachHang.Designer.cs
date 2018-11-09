namespace Quan_Ly_Kinh_Doanh.DisplayLayer
{
    partial class FormKhachHang
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
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.othersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lọcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.theoGiớiTínhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhỏHơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocTuoiNhoHontoolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.lớnHơnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LocTuoiLonHontoolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tìmKiếmTheoTênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimTheotentoolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.dgvKHACHHANG = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialogImg = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbGioiTinh = new System.Windows.Forms.ComboBox();
            this.menuStripMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHACHHANG)).BeginInit();
            this.pnlHienThi.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.BackColor = System.Drawing.Color.Beige;
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.menuStripMain.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStripMain.Size = new System.Drawing.Size(1299, 28);
            this.menuStripMain.TabIndex = 0;
            this.menuStripMain.Text = "menuStrip1";
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.reload2;
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(69, 24);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.edit;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.save;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.cancel;
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // othersToolStripMenuItem
            // 
            this.othersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lọcToolStripMenuItem,
            this.tìmKiếmTheoTênToolStripMenuItem});
            this.othersToolStripMenuItem.Image = global::Quan_Ly_Kinh_Doanh.Properties.Resources.other2;
            this.othersToolStripMenuItem.Name = "othersToolStripMenuItem";
            this.othersToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.othersToolStripMenuItem.Text = "Others";
            // 
            // lọcToolStripMenuItem
            // 
            this.lọcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.theoGiớiTínhToolStripMenuItem});
            this.lọcToolStripMenuItem.Name = "lọcToolStripMenuItem";
            this.lọcToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.lọcToolStripMenuItem.Text = "Lọc";
            // 
            // theoGiớiTínhToolStripMenuItem
            // 
            this.theoGiớiTínhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nhỏHơnToolStripMenuItem,
            this.lớnHơnToolStripMenuItem});
            this.theoGiớiTínhToolStripMenuItem.Name = "theoGiớiTínhToolStripMenuItem";
            this.theoGiớiTínhToolStripMenuItem.Size = new System.Drawing.Size(147, 26);
            this.theoGiớiTínhToolStripMenuItem.Text = "Theo tuổi";
            // 
            // nhỏHơnToolStripMenuItem
            // 
            this.nhỏHơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocTuoiNhoHontoolStripTextBox1});
            this.nhỏHơnToolStripMenuItem.Name = "nhỏHơnToolStripMenuItem";
            this.nhỏHơnToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.nhỏHơnToolStripMenuItem.Text = "Nhỏ hơn";
            // 
            // LocTuoiNhoHontoolStripTextBox1
            // 
            this.LocTuoiNhoHontoolStripTextBox1.Name = "LocTuoiNhoHontoolStripTextBox1";
            this.LocTuoiNhoHontoolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.LocTuoiNhoHontoolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocTuoiNhoHontoolStripTextBox1_KeyDown);
            // 
            // lớnHơnToolStripMenuItem
            // 
            this.lớnHơnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LocTuoiLonHontoolStripTextBox1});
            this.lớnHơnToolStripMenuItem.Name = "lớnHơnToolStripMenuItem";
            this.lớnHơnToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.lớnHơnToolStripMenuItem.Text = "Lớn hơn";
            // 
            // LocTuoiLonHontoolStripTextBox1
            // 
            this.LocTuoiLonHontoolStripTextBox1.Name = "LocTuoiLonHontoolStripTextBox1";
            this.LocTuoiLonHontoolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.LocTuoiLonHontoolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LocTuoiLonHontoolStripTextBox1_KeyDown);
            // 
            // tìmKiếmTheoTênToolStripMenuItem
            // 
            this.tìmKiếmTheoTênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimTheotentoolStripTextBox1});
            this.tìmKiếmTheoTênToolStripMenuItem.Name = "tìmKiếmTheoTênToolStripMenuItem";
            this.tìmKiếmTheoTênToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.tìmKiếmTheoTênToolStripMenuItem.Text = "Tìm kiếm theo tên";
            // 
            // TimTheotentoolStripTextBox1
            // 
            this.TimTheotentoolStripTextBox1.Name = "TimTheotentoolStripTextBox1";
            this.TimTheotentoolStripTextBox1.Size = new System.Drawing.Size(100, 27);
            this.TimTheotentoolStripTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TimTheotentoolStripTextBox1_KeyDown);
            // 
            // dgvKHACHHANG
            // 
            this.dgvKHACHHANG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKHACHHANG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKHACHHANG.Location = new System.Drawing.Point(16, 180);
            this.dgvKHACHHANG.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvKHACHHANG.Name = "dgvKHACHHANG";
            this.dgvKHACHHANG.Size = new System.Drawing.Size(1069, 350);
            this.dgvKHACHHANG.TabIndex = 1;
            this.dgvKHACHHANG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKHACHHANG_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mã KH";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(84, 17);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(135, 22);
            this.txtMaKH.TabIndex = 3;
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.Controls.Add(this.cbbGioiTinh);
            this.pnlHienThi.Controls.Add(this.label6);
            this.pnlHienThi.Controls.Add(this.dtpNgaySinh);
            this.pnlHienThi.Controls.Add(this.label5);
            this.pnlHienThi.Controls.Add(this.txtDienThoai);
            this.pnlHienThi.Controls.Add(this.label4);
            this.pnlHienThi.Controls.Add(this.txtDiaChi);
            this.pnlHienThi.Controls.Add(this.label3);
            this.pnlHienThi.Controls.Add(this.txtTenKH);
            this.pnlHienThi.Controls.Add(this.label2);
            this.pnlHienThi.Controls.Add(this.txtMaKH);
            this.pnlHienThi.Controls.Add(this.label1);
            this.pnlHienThi.Location = new System.Drawing.Point(16, 33);
            this.pnlHienThi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(1084, 139);
            this.pnlHienThi.TabIndex = 4;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(84, 79);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(135, 22);
            this.dtpNgaySinh.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 82);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ngày sinh";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.Location = new System.Drawing.Point(933, 17);
            this.txtDienThoai.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.Size = new System.Drawing.Size(136, 22);
            this.txtDienThoai.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(852, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Điện thoại";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(443, 74);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(285, 22);
            this.txtDiaChi.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Địa chỉ";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(443, 17);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(285, 22);
            this.txtTenKH.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên KH";
            // 
            // openFileDialogImg
            // 
            this.openFileDialogImg.FileName = "openFileDialogIMG";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(852, 83);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Giới tính";
            // 
            // cbbGioiTinh
            // 
            this.cbbGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGioiTinh.FormattingEnabled = true;
            this.cbbGioiTinh.Location = new System.Drawing.Point(933, 72);
            this.cbbGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.cbbGioiTinh.Name = "cbbGioiTinh";
            this.cbbGioiTinh.Size = new System.Drawing.Size(136, 24);
            this.cbbGioiTinh.TabIndex = 23;
            // 
            // FormKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1299, 544);
            this.Controls.Add(this.pnlHienThi);
            this.Controls.Add(this.dgvKHACHHANG);
            this.Controls.Add(this.menuStripMain);
            this.MainMenuStrip = this.menuStripMain;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormKhachHang";
            this.Text = "Quản thông tin khách hàng";
            this.Load += new System.EventHandler(this.FormKhachHang_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKHACHHANG)).EndInit();
            this.pnlHienThi.ResumeLayout(false);
            this.pnlHienThi.PerformLayout();
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
        private System.Windows.Forms.DataGridView dgvKHACHHANG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Panel pnlHienThi;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog openFileDialogImg;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ToolStripMenuItem lọcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem theoGiớiTínhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhỏHơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox LocTuoiNhoHontoolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem lớnHơnToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox LocTuoiLonHontoolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmTheoTênToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox TimTheotentoolStripTextBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbGioiTinh;
    }
}