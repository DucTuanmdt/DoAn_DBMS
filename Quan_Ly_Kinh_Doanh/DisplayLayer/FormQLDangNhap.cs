using Quan_Ly_Kinh_Doanh.BSLayer;
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
    public partial class FormQLDangNhap : Form
    {
        public FormQLDangNhap()
        {
            InitializeComponent();
        }
        
        BLDangNhap dbKH = new BLDangNhap();
        bool isThem = false;
        string err = "";

        void SetEnableTextBox(bool isEnable)
        {
            cbbPhanQuyen.Enabled = isEnable;
            txtUsername.ReadOnly = !isEnable;
            txtMatKhau.ReadOnly = !isEnable;
        }

        void ResetTextBox()
        {

            txtUsername.ResetText();
            txtMatKhau.ResetText();
        }

        void SetMenuEnable(bool isEnable)
        {
            saveToolStripMenuItem.Enabled = isEnable;
            cancelToolStripMenuItem.Enabled = isEnable;

            addToolStripMenuItem.Enabled = !isEnable;
            editToolStripMenuItem.Enabled = !isEnable;
            deleteToolStripMenuItem.Enabled = !isEnable;
        }

        //Đang trong chế độ xem
        void SetXem()
        {
            SetEnableTextBox(false);
            SetMenuEnable(false);
            dgvDangNhap.Enabled = true;
        }

        //Đang trong chế độ sửa
        void SetThemSua()
        {
            SetMenuEnable(true);
        }

        void LoadData()
        {
            try
            {
                dgvDangNhap.DataSource = dbKH.LayDangNhap();
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvPHONGBAN_CellClick(null, null);
            }
            catch
            {
                this.Enabled = false;
                MessageBox.Show("Bạn không có quyền truy cập!");
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThem = true;
            ResetTextBox();
            SetThemSua();
            SetEnableTextBox(true);
            txtUsername.Focus();
        }

        //bool KiemTraMatKhauCu()
        //{
        //    if (dbKH.KiemTraDangNhap(txtUsername.Text, txtMatKhau.Text) == true)
        //    {
        //        MessageBox.Show("Hãy nhập mật khẩu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return true;
        //    }

        //    MessageBox.Show("Bạn đã nhập sai password cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    txtMatKhau.ReadOnly = true;
        //    SetXem();
        //    SetEnableTextBox(false);

        //    return false;
        //}



        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hãy nhập lại mật khẩu cũ!", "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //txtMatKhau.ReadOnly = false;
            //txtMatKhau.Focus();
            SetMenuEnable(true);
            dgvDangNhap.Enabled = false;
            txtMatKhau.ReadOnly = false;
            cbbPhanQuyen.Enabled = true;
            //ResetTextBox();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txtUsername.Text;
                var traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == System.Windows.Forms.DialogResult.Yes)
                {
                    dbKH.XoaDangNhap(MaNV, ref err);
                    LoadData();
                    MessageBox.Show("Đã xóa mẫu tin!");
                }
            }
            catch
            {
                MessageBox.Show("Đã xảy ra lỗi! Không xóa được mẫu tin.");
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isThem == true)
            {
                try
                {
                    BLDangNhap blKH = new BLDangNhap();
                    blKH.ThemDangNhap(txtUsername.Text, txtMatKhau.Text, cbbPhanQuyen.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã thêm xong!");
                }
                catch
                {
                    MessageBox.Show("Đã xảy ra lỗi! Không thêm được mẫu tin!");
                }
            }
            else
            {
                try
                {
                    BLDangNhap blKH = new BLDangNhap();
                    blKH.CapNhatDangNhap(txtUsername.Text, txtMatKhau.Text, cbbPhanQuyen.Text, ref err);
                    LoadData();
                    MessageBox.Show("Đã sửa xong!");
                }
                catch
                {
                    MessageBox.Show("Đã xảy ra lỗi! Không sửa được mẫu tin!");
                }
            }
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetXem();
            SetEnableTextBox(false);
            dgvPHONGBAN_CellClick(null, null);
        }

        private void FormPhongBan_Load(object sender, EventArgs e)
        {
            LoadData();
            KhoiTaoGiaTriComboBox();
            //btnXacNhan.Hide();
        }

        //Cái này dùng kỹ thuật Binding thì hay hơn, nhưng chưa kịp test lỗi nên chưa dùng
        private void dgvPHONGBAN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvDangNhap.CurrentCell.RowIndex;
            int count = 0;
            txtUsername.Text = dgvDangNhap.Rows[r].Cells[count++].Value.ToString();
            txtMatKhau.Text = dgvDangNhap.Rows[r].Cells[count++].Value.ToString();
            cbbPhanQuyen.Text = dgvDangNhap.Rows[r].Cells[count++].Value.ToString();

        }

        void KhoiTaoGiaTriComboBox()
        {
            List<string> phanquyen = new List<string>() { "Admin", "Moderator", "Staff" };
            cbbPhanQuyen.DataSource = phanquyen;
        }

        
    }
}
