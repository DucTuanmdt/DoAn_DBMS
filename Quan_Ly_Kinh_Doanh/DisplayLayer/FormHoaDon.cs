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
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        
        BLHoaDon dbKH = new BLHoaDon();
        bool isThem = false;
        string err = "";

        void SetEnableTextBox(bool isEnable)
        {
            cbbTenNV.Enabled = isEnable;
            txtMaHD.ReadOnly = !isEnable;
            cbbTenKH.Enabled = isEnable;
            dtpNgayLapHD.Enabled = isEnable;
            dtpNgayNhanHang.Enabled = isEnable;
        }

        void ResetTextBox()
        {
            txtMaHD.ResetText();
            cbbTenKH.ResetText();
            cbbTenNV.ResetText();
            dtpNgayLapHD.ResetText();
            dtpNgayNhanHang.ResetText();

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
            dgvHOADON.Enabled = true;
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
                dgvHOADON.DataSource = dbKH.LayHoaDon();
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvHOADON_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table HoaDon. Lỗi rồi!");
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
            txtMaHD.ReadOnly = true;
            txtMaHD.Text = dbKH.SinhMaHDMoi(dgvHOADON.Rows[dgvHOADON.Rows.Count - 2].Cells[0].Value.ToString());
            dgvHOADON.Enabled = false;
            cbbTenKH.Focus();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThem = false;
            dgvHOADON_CellClick(null, null);
            SetThemSua();
            SetEnableTextBox(true);
            txtMaHD.ReadOnly = true;
            cbbTenKH.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaHD = txtMaHD.Text;
                var traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == System.Windows.Forms.DialogResult.Yes)
                {
                    dbKH.XoaHoaDon(MaHD, ref err);
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
                    BLHoaDon blKH = new BLHoaDon();
                    blKH.ThemHoaDon(txtMaHD.Text, cbbTenKH.Text, cbbTenNV.Text,
                        dtpNgayLapHD.Value, dtpNgayNhanHang.Value, ref err);
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
                    BLHoaDon blKH = new BLHoaDon();
                    blKH.CapNhatHoaDon(txtMaHD.Text, cbbTenKH.Text, cbbTenNV.Text,
                        dtpNgayLapHD.Value, dtpNgayNhanHang.Value, ref err);
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
            dgvHOADON_CellClick(null, null);
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
            KhoiTaoGiaTriComboBox();
        }

        //Cái này dùng kỹ thuật Binding thì hay hơn, nhưng chưa kịp test lỗi nên chưa dùng
        private void dgvHOADON_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvHOADON.CurrentCell.RowIndex;
            int count = 0;
            txtMaHD.Text = dgvHOADON.Rows[r].Cells[count++].Value.ToString();
            cbbTenKH.Text = dgvHOADON.Rows[r].Cells[count++].Value.ToString();
            cbbTenNV.Text = dgvHOADON.Rows[r].Cells[count++].Value.ToString();
            dtpNgayLapHD.Value = DateTime.Parse(dgvHOADON.Rows[r].Cells[count++].Value.ToString());
            dtpNgayNhanHang.Value = DateTime.Parse(dgvHOADON.Rows[r].Cells[count++].Value.ToString());

        }

        void KhoiTaoGiaTriComboBox()
        {
            cbbTenKH.DataSource = dbKH.LayDSTenKH();
            cbbTenNV.DataSource = dbKH.LayDSTenNV();
        }

        void LoadData2(DataTable dtSource)
        {
            try
            {
                KhoiTaoGiaTriComboBox();
                dgvHOADON.DataSource = dtSource;
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvHOADON_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table KhachHang. Lỗi rồi!");
            }
        }

        private void TimKiemTheoNVtoolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox chuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbKH.LayHoaDonTheoTimKiem(KieuTimKiemHoaDon.THEO_NV, chuoiCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }

        private void TimKiemTheoKHtoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox chuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbKH.LayHoaDonTheoTimKiem(KieuTimKiemHoaDon.THEO_KH, chuoiCanTim.Text);
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
