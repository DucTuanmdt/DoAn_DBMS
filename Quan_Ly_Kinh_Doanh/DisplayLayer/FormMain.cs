using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh.DisplayLayer
{
    public partial class FormMain : Form
    {
        //Test xong thì sửa lại dòng này thành isLoginSuccess = false;
        public static bool isLoginSuccess = true;

        public FormMain()
        {
            InitializeComponent();
        }

        private void dangNhapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Test Xong mở khóa 2 dòng này

            //FormDangNhap frmDangNhap = new FormDangNhap();
            //frmDangNhap.ShowDialog();

            if (FormMain.isLoginSuccess == true)
            {
                dangNhapToolStripMenuItem.Enabled = false;
                pnlHienThi.Enabled = true;
            }
            
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
            
            Application.Exit();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var traloi = MessageBox.Show("Bạn có chắc chắn muốn thoát?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == System.Windows.Forms.DialogResult.Cancel)
                e.Cancel = true;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThemTabPage(new ThongKe());
        }
    }
}
