using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.EntityClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh.DisplayLayer
{
    public partial class FormMain : Form
    {
        //Test xong thì sửa lại dòng này thành isLoginSuccess = false;
        public static bool isLoginSuccess = false;
        private string _conString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["QuanLySieuThiEntities"].ConnectionString; } }

        public FormMain()
        {
            InitializeComponent();
        }

        private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            XuLyDangNhapServer();
        }

        public static bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }

        int KiemTraTabTonTai(Form frm)
        {
            for (int i = 0; i < tabcHienThi.TabPages.Count; i++)
            {
                if (tabcHienThi.TabPages[i].Text.Trim() == frm.Text.Trim())
                    return i;
            }

            return -1;
        }

        void ThemTabPage(Form frmOpen)
        {
            int index = KiemTraTabTonTai(frmOpen);

            if (index >= 0)
            {
                tabcHienThi.SelectedTab = tabcHienThi.TabPages[index];
                return;
            }

            TabPage tab = new TabPage() { Text = frmOpen.Text };
            tabcHienThi.TabPages.Add(tab);
            tabcHienThi.SelectedTab = tab;

            frmOpen.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            frmOpen.TopLevel = false;
            frmOpen.Parent = tab;
            frmOpen.Dock = DockStyle.Fill;
            frmOpen.Show();
        }

        void XoaTatCaTabPage()
        {
            while (tabcHienThi.TabPages.Count > 0)
            {
                tabcHienThi.TabPages.Remove(tabcHienThi.TabPages[0]);
            }
                
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            int imgsize = 45;
            btnSanPham.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.qlsp, 
                new Size(imgsize, imgsize)));
            btnNhanVien.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.qlnv,
                new Size(imgsize, imgsize)));
            btnPhongBan.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.qlpb,
                new Size(imgsize, imgsize)));
            btnKhachHang.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.qlkh,
                new Size(imgsize, imgsize)));
            btnHoaDon.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.qlhd3,
                new Size(imgsize, imgsize)));
            btnChiTietHoaDon.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.qlcthd,
                new Size(imgsize, imgsize)));
            btnThongKe.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.report,
                new Size(imgsize, imgsize)));
            btnDangNhap.Image = (Image)(new Bitmap(Quan_Ly_Kinh_Doanh.Properties.Resources.qldn,
                new Size(imgsize, imgsize)));

            pnlHienThi.Enabled = false;
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            ThemTabPage(new FormSanPham());
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            ThemTabPage(new FormNhanVien());
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            ThemTabPage(new FormKhachHang());
        }

        private void btnPhongBan_Click(object sender, EventArgs e)
        {
            ThemTabPage(new FormPhongBan());
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ThemTabPage(new FormHoaDon());
        }

        private void btnChiTietHoaDon_Click(object sender, EventArgs e)
        {
            ThemTabPage(new FormChiTietHoaDon());
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            ThemTabPage(new FormQLDangNhap());
        }

        private void ThoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaTatCaTabPage();
            ThoatToolStripMenuItem.Enabled = false;
            dangNhapToolStripMenuItem.Enabled = true;
            pnlHienThi.Enabled = false;
            FormMain.isLoginSuccess = false;
            //Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                ThemTabPage(new ThongKe());
            }
            catch (Exception e2)
            {
                MessageBox.Show("Không truy xuất được! " + e2.Message);
            }
        }



        ///Dang Nhap Server

        public string Username = "";
        public string Password = "";

        public void XuLyDangNhapServer()
        {
            SinhFormDangNhap();
            
            if (FormMain.isLoginSuccess == true)
            {
                ThoatToolStripMenuItem.Enabled = true;
                dangNhapToolStripMenuItem.Enabled = false;
                pnlHienThi.Enabled = true;
            }
        }

        //Kiểm tra Server máy chủ có tồn tại hay không
        public static bool CheckPing(string ip)
        {
            System.Net.NetworkInformation.Ping pingSender = new Ping();
            PingReply reply = pingSender.Send(ip);

            if (reply.Status == IPStatus.Success)
                return true;

            return false;
        }

        //Kiểm tra kết ConnectionString

        public bool CheckConnection()
        {
            string DtaSrc = Properties.Settings.Default.DataSource;
            String DtaBs = Properties.Settings.Default.Database;
            if (DtaSrc.IndexOf("192.168.") == 0)
            {
                if (!CheckPing(DtaSrc))
                {
                    MessageBox.Show("Không tìm thấy server!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }            

            using (QuanLySieuThiEntities dbContext = new QuanLySieuThiEntities(BuildConnectionString(DtaSrc, DtaBs)))
            {
                if (dbContext.Database.Exists())
                {
                    MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền truy cập!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
        }
        
        public bool SetConnectionString()
        {
            if (!CheckConnection())
            {
                return false;
            }

            String DtaSrc = Properties.Settings.Default.DataSource;
            String DtaBs = Properties.Settings.Default.Database;

            string myString = BuildConnectionString(DtaSrc, DtaBs);
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["QuanLySieuThiEntities"].ConnectionString = myString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");

            return true;
        }

        public void SetData(FormLoginServer frm)
        {
            Properties.Settings.Default.DataSource = frm.Datasource;
            Properties.Settings.Default.Database = frm.Database;
            Properties.Settings.Default.Username = frm.Username;
            Username = frm.Username;
            Password = frm.Password;
            Properties.Settings.Default.Save();
        }
        public void SinhFormDangNhap()
        {
            FormLoginServer frm = new FormLoginServer(this, Username, Password);
            frm.Datasource = Properties.Settings.Default.DataSource;
            frm.ShowDialog();
        }

        public void CheckTruyCapServer()
        {
            if (!SetConnectionString())
            {
                FormMain.isLoginSuccess = false;
                return;
            }
            using (QuanLySieuThiEntities entities = new QuanLySieuThiEntities(_conString))
            {
                try
                {
                    // Query the product table to find how many products are in the inventory

                    var prodCount = (from p in entities.SANPHAMs select p).Count();
                    FormMain.isLoginSuccess = true;
                }
                catch (Exception f)
                {
                    MessageBox.Show("Không truy xuất được: " + f.Message);
                    FormMain.isLoginSuccess = false;
                }
            }

        }
        //
        private String BuildConnectionString(String DataSource, String Database)
        {
            String connString = @"data source=" + DataSource + ";initial catalog=" + Database + ";" + "user id=" + Username + ";password=" + Password + ";MultipleActiveResultSets=True;App=EntityFramework&quot;";

            EntityConnectionStringBuilder esb = new EntityConnectionStringBuilder();
            esb.Metadata = "res://*/QuanLySieuThi.csdl|res://*/QuanLySieuThi.ssdl|res://*/QuanLySieuThi.msl";
            esb.Provider = "System.Data.SqlClient";
            esb.ProviderConnectionString = connString;

            return esb.ToString();
        }


        //public QuanLySieuThiEntities(String connString)
        //    : base(connString)
        //{
        //}

        //[global::System.Configuration.UserScopedSettingAttribute()]
        //[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        //[global::System.Configuration.DefaultSettingValueAttribute("192.168.22.1")]
        //public string DataSource
        //{
        //    get
        //    {
        //        return ((string)(this["DataSource"]));
        //    }
        //    set
        //    {
        //        this["DataSource"] = value;
        //    }
        //}

        //[global::System.Configuration.UserScopedSettingAttribute()]
        //[global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        //[global::System.Configuration.DefaultSettingValueAttribute("QuanLySieuThi")]
        //public string Database
        //{
        //    get
        //    {
        //        return ((string)(this["Database"]));
        //    }
        //    set
        //    {
        //        this["Database"] = value;
        //    }
        //}
    }
    
}

