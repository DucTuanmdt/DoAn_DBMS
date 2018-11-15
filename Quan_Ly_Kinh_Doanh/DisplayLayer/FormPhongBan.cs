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
    public partial class FormPhongBan : Form
    {
        public FormPhongBan()
        {
            InitializeComponent();
        }
        
        BLPhongBan dbKH = new BLPhongBan();
        bool isThem = false;
        string err = "";

        void SetEnableTextBox(bool isEnable)
        {
            cbbTenTruongPhong.Enabled = isEnable;
            txtMaPB.ReadOnly = !isEnable;
            txtTenPhong.ReadOnly = !isEnable;
        }

        void ResetTextBox()
        {
            txtMaPB.ResetText();
            txtTenPhong.ResetText();
            cbbTenTruongPhong.ResetText();
        }

        void SetMenuEnable(bool isEnable)
        {
            saveToolStripMenuItem.Enabled = isEnable;
            cancelToolStripMenuItem.Enabled = isEnable;

            othersToolStripMenuItem.Enabled = !isEnable;
            addToolStripMenuItem.Enabled = !isEnable;
            editToolStripMenuItem.Enabled = !isEnable;
            deleteToolStripMenuItem.Enabled = !isEnable;
        }

        //Đang trong chế độ xem
        void SetXem()
        {
            SetMenuEnable(false);
            dgvPhongBan.Enabled = true;
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
                KhoiTaoGiaTriComboBox();
                dgvPhongBan.DataSource = dbKH.LayPhongBan();
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvPHONGBAN_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table PhongBan. Lỗi rồi!");
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
            txtMaPB.ReadOnly = true;
            txtMaPB.Text = dbKH.SinhMaPBMoi(dgvPhongBan.Rows[dgvPhongBan.Rows.Count - 2].Cells[0].Value.ToString());
            dgvPhongBan.Enabled = false;
            txtTenPhong.Focus();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThem = false;
            dgvPHONGBAN_CellClick(null, null);
            SetThemSua();
            SetEnableTextBox(true);
            txtMaPB.ReadOnly = true;
            txtTenPhong.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = txtMaPB.Text;
                var traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == System.Windows.Forms.DialogResult.Yes)
                {
                    bool isSuccess = dbKH.XoaPhongBan(MaKH, ref err);
                    if (isSuccess == false)
                    {
                        MessageBox.Show("Bạn không được cấp quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadData();

                        return;
                    }

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
                    BLPhongBan blKH = new BLPhongBan();
                    bool isSuccess = blKH.ThemPhongBan(txtMaPB.Text, txtTenPhong.Text, cbbTenTruongPhong.Text, ref err);
                     
                    if (isSuccess == false)
                    {
                        MessageBox.Show("Bạn không được cấp quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadData();

                        return;
                    }

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
                    BLPhongBan blKH = new BLPhongBan();
                    bool isSuccess = blKH.CapNhatPhongBan(txtMaPB.Text, txtTenPhong.Text, cbbTenTruongPhong.Text,ref err);

                    if (isSuccess == false)
                    {
                        MessageBox.Show("Bạn không được cấp quyền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        LoadData();

                        return;
                    }
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
        }

        //Cái này dùng kỹ thuật Binding thì hay hơn, nhưng chưa kịp test lỗi nên chưa dùng
        private void dgvPHONGBAN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvPhongBan.CurrentCell.RowIndex;
            int count = 0;
            txtMaPB.Text = dgvPhongBan.Rows[r].Cells[count++].Value.ToString();
            txtTenPhong.Text = dgvPhongBan.Rows[r].Cells[count++].Value.ToString();
            cbbTenTruongPhong.Text = dgvPhongBan.Rows[r].Cells[count++].Value.ToString();
        }

        void KhoiTaoGiaTriComboBox()
        {
            cbbTenTruongPhong.DataSource = dbKH.LayDSTenNV();
        }

        void LoadData2(DataTable dtSource)
        {
            try
            {
                KhoiTaoGiaTriComboBox();
                dgvPhongBan.DataSource = dtSource;
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvPHONGBAN_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table KhachHang. Lỗi rồi!");
            }
        }

        private void TimKiemTheoTruongPhongtoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox chuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbKH.LayPhongBanTheoTimKiem(KieuTimKiemPhongBan.THEO_TRUONG_PHONG, chuoiCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }

        private void TimKiemTenPhongtoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox chuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbKH.LayPhongBanTheoTimKiem(KieuTimKiemPhongBan.THEO_TEN_PHONG, chuoiCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }


    }
}
