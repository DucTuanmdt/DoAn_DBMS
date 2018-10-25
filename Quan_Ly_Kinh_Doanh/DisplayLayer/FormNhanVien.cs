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

namespace Quan_Ly_Kinh_Doanh
{
    public partial class FormNhanVien : Form
    {
        public FormNhanVien()
        {
            InitializeComponent();
        }
        BLNhanVien dbNV = new BLNhanVien();
        bool isThem = false;
        string err = "";

        void SetEnableTextBox(bool isEnable)
        {
            txtMaNV.ReadOnly = !isEnable;
            txtHo.ReadOnly = !isEnable;
            txtTenLot.ReadOnly = !isEnable;
            txtTen.ReadOnly = !isEnable;
            cbbGioiTinh.Enabled = isEnable;
            cbbTenPhong.Enabled = isEnable;
            txtLuongCB.ReadOnly = !isEnable;
            txtDienThoai.ReadOnly = !isEnable;
            dtpNgaySinh.Enabled = isEnable;
        }

        void ResetTextBox()
        {
            txtMaNV.ResetText();
            txtHo.ResetText();
            txtTenLot.ResetText();
            txtTen.ResetText();
            cbbGioiTinh.ResetText();
            cbbTenPhong.ResetText();
            txtLuongCB.ResetText();
            txtDienThoai.ResetText();
            dtpNgaySinh.ResetText();
        }

        void SetMenuEnable(bool isEnable)
        {
            saveToolStripMenuItem.Enabled = isEnable;
            cancelToolStripMenuItem.Enabled = isEnable;
            btnLoadFileImg.Enabled = isEnable;

            addToolStripMenuItem.Enabled = !isEnable;
            editToolStripMenuItem.Enabled = !isEnable;
            deleteToolStripMenuItem.Enabled = !isEnable;
        }

        //Đang trong chế độ xem
        void SetXem()
        {
            SetMenuEnable(false);
            dgvNHANVIEN.Enabled = true;
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
                dgvNHANVIEN.DataSource = dbNV.LayNhanVien();
                dgvNHANVIEN.Enabled = true;
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                btnLoadFileImg.Enabled = false;
                SetXem();
                dgvSANPHAM_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table NhanVien. Lỗi rồi!");
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
            txtMaNV.ReadOnly = true;
            dgvNHANVIEN.Enabled = false;
            txtMaNV.Text = dbNV.SinhMaNVMoi(dgvNHANVIEN.Rows[dgvNHANVIEN.Rows.Count - 2].Cells[0].Value.ToString());
            pcbHinhAnh.Image = Quan_Ly_Kinh_Doanh.Properties.Resources.hinhtam;
            txtHo.Focus();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThem = false;
            dgvSANPHAM_CellClick(null, null);
            //dgvNHANVIEN_RowLeave(null, null);
            SetThemSua();
            SetEnableTextBox(true);
            txtMaNV.ReadOnly = true;
            txtHo.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaNV = txtMaNV.Text;
                var traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == System.Windows.Forms.DialogResult.Yes)
                {
                    dbNV.XoaNhanVien(MaNV, ref err);
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
            dgvNHANVIEN.Enabled = true;
            if (isThem == true)
            {
                try
                {
                    BLNhanVien blNV = new BLNhanVien();
                    blNV.ThemNhanVien(txtMaNV.Text, txtHo.Text, txtTenLot.Text,
                        txtTen.Text, dtpNgaySinh.Value, cbbGioiTinh.Text,
                        cbbTenPhong.Text, txtLuongCB.Text, txtDienThoai.Text,
                        pcbHinhAnh.Image, ref err);
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
                    BLNhanVien blNV = new BLNhanVien();
                    blNV.CapNhatNhanVien(txtMaNV.Text, txtHo.Text, txtTenLot.Text,
                        txtTen.Text, dtpNgaySinh.Value, cbbGioiTinh.Text,
                        cbbTenPhong.Text, txtLuongCB.Text, txtDienThoai.Text,
                        pcbHinhAnh.Image, ref err);
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
            dgvSANPHAM_CellClick(null, null);
            //dgvNHANVIEN_RowLeave(null, null);
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
            KhoiTaoGiaTriComboBox();
        }

        //Cái này dùng kỹ thuật Binding thì hay hơn, nhưng chưa kịp test lỗi nên chưa dùng
        private void dgvSANPHAM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvNHANVIEN.CurrentCell.RowIndex;
            if (r >= dgvNHANVIEN.Rows.Count - 1)
                return;
            int count = 0;
            txtMaNV.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            txtHo.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            txtTenLot.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            txtTen.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString());
            cbbGioiTinh.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            cbbTenPhong.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            txtLuongCB.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            txtDienThoai.Text = dgvNHANVIEN.Rows[r].Cells[count++].Value.ToString();
            pcbHinhAnh.Image = dbNV.LayHinhAnhNhanVien(txtMaNV.Text);
        }

        private void btnLoadFileImg_Click(object sender, EventArgs e)
        {
            var traloi = openFileDialogImg.ShowDialog();

            if (traloi == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialogImg.FileName;
                if (string.IsNullOrEmpty(file))
                    return;
                pcbHinhAnh.Image = Image.FromFile(file); ;
            }
        }

        void LoadData2(DataTable dtSource)
        {
            try
            {
                KhoiTaoGiaTriComboBox();
                dgvNHANVIEN.DataSource = dtSource;
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                btnLoadFileImg.Enabled = false;
                SetXem();
                dgvSANPHAM_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table NhanVien. Lỗi rồi!");
            }
        }

        private void XepTenTangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoSapXep(KieuSapXepNhanVien.THEO_TEN, true));
        }

        private void XepLuongTangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoSapXep(KieuSapXepNhanVien.THEO_LUONG, true));
        }

        private void XepTuoiTangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoSapXep(KieuSapXepNhanVien.THEO_TUOI, true));
        }

        private void XepTenGiamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoSapXep(KieuSapXepNhanVien.THEO_TEN, false));
        }

        private void XepLuongGiamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoSapXep(KieuSapXepNhanVien.THEO_LUONG, false));
        }

        private void XepTuoiGiamToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoSapXep(KieuSapXepNhanVien.THEO_TUOI, false));
        }

        private void TimTentoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tenCanTim = sender as ToolStripTextBox;
                LoadData2(dbNV.LayNhanVienTheoTimKiem(KieuTimKiemNhanVien.THEO_TEN, tenCanTim.Text));
            }
        }

        private void TimMaNVtoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tenCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbNV.LayNhanVienTheoTimKiem(KieuTimKiemNhanVien.THEO_ID, tenCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }

        private void LocNamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoLoc(KieuLocNhanVien.THEO_NAM, true, ""));
        }

        private void LocNuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadData2(dbNV.LayNhanVienTheoLoc(KieuLocNhanVien.THEO_NU, true, ""));
        }

        private void LocTuoiLonHontoolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbNV.LayNhanVienTheoLoc(KieuLocNhanVien.THEO_TUOI, true, tuoiCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }

        private void LocTuoiNhoHontoolStripTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbNV.LayNhanVienTheoLoc(KieuLocNhanVien.THEO_TUOI, false, tuoiCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }

        void KhoiTaoGiaTriComboBox()
        {
            List<string> gioitinh = new List<string>() {"Nam", "Nữ"};
            cbbGioiTinh.DataSource = gioitinh;

            cbbTenPhong.DataSource = dbNV.LayDSTenPhong();
            cbbTenPhong.DisplayMember = "TenPhong";

        }
    }
}
