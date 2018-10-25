using Quan_Ly_Kinh_Doanh.BSLayer;
using Quan_Ly_Kinh_Doanh.DisplayLayer;
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
    public partial class FormSanPham : Form
    {
        BLSanPham dbSP = new BLSanPham();
        bool isThem = false;
        string err = "";
        public FormSanPham()
        {
            InitializeComponent();
        }

        void SetEnableTextBox(bool isEnable)
        {
            txtDonViTinh.ReadOnly = !isEnable;
            txtGiaBan.ReadOnly = !isEnable;
            txtMaSP.ReadOnly = !isEnable;
            txtTenSP.ReadOnly = !isEnable;
        }

        void ResetTextBox()
        {
            txtMaSP.ResetText();
            txtTenSP.ResetText();
            txtDonViTinh.ResetText();
            txtGiaBan.ResetText();
        }

        void SetMenuEnable(bool isEnable)
        {
            saveToolStripMenuItem.Enabled = isEnable;
            cancelToolStripMenuItem.Enabled = isEnable;
            btnLoadFileImg.Enabled = isEnable;

            othersToolStripMenuItem.Enabled = !isEnable;
            addToolStripMenuItem.Enabled = !isEnable;
            editToolStripMenuItem.Enabled = !isEnable;
            deleteToolStripMenuItem.Enabled = !isEnable;
        }

        //Đang trong chế độ xem
        void SetXem()
        {
            SetMenuEnable(false);
            dgvSANPHAM.Enabled = true;
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
                dgvSANPHAM.DataSource = dbSP.LaySanPham();
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                btnLoadFileImg.Enabled = false;
                SetXem();
                dgvSANPHAM.Enabled = true;
                dgvSANPHAM_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table SanPham. Lỗi rồi!");
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
            txtMaSP.ReadOnly = true;
            dgvSANPHAM.Enabled = false;
            txtMaSP.Text = dbSP.SinhMaSPMoi(dgvSANPHAM.Rows[dgvSANPHAM.Rows.Count - 2].Cells[0].Value.ToString());
            pcbHinhAnh.Image = Quan_Ly_Kinh_Doanh.Properties.Resources.hinhtamsp;
            txtMaSP.Focus();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThem = false;
            dgvSANPHAM_CellClick(null, null);
            SetThemSua();
            SetEnableTextBox(true);
            txtMaSP.ReadOnly = true;
            txtTenSP.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaSP = txtMaSP.Text;
                var traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == System.Windows.Forms.DialogResult.Yes)
                {
                    dbSP.XoaSanPham(MaSP, ref err);
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
                    if (FormMain.IsNumber(txtGiaBan.Text) == true)
                    {
                        BLSanPham blSP = new BLSanPham();
                        blSP.ThemSanPham(txtMaSP.Text, txtTenSP.Text,
                            txtDonViTinh.Text, txtGiaBan.Text, pcbHinhAnh.Image, ref err);
                        LoadData();
                        MessageBox.Show("Đã thêm xong!");
                    }
                    else
                    {
                        MessageBox.Show("Giá bán phải là một số!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                    BLSanPham blSP = new BLSanPham();
                    blSP.CapNhatSanPham(txtMaSP.Text, txtTenSP.Text,
                            txtDonViTinh.Text, txtGiaBan.Text, pcbHinhAnh.Image, ref err);
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
        }

        private void FormSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //Cái này dùng kỹ thuật Binding thì hay hơn, nhưng chưa kịp test lỗi nên chưa dùng
        private void dgvSANPHAM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvSANPHAM.CurrentCell.RowIndex;
            txtMaSP.Text = dgvSANPHAM.Rows[r].Cells[0].Value.ToString();
            txtTenSP.Text = dgvSANPHAM.Rows[r].Cells[1].Value.ToString();
            txtDonViTinh.Text = dgvSANPHAM.Rows[r].Cells[2].Value.ToString();
            txtGiaBan.Text = dgvSANPHAM.Rows[r].Cells[3].Value.ToString();
            pcbHinhAnh.Image = dbSP.LayHinhAnhSanPham(txtMaSP.Text);
        }

        private void btnLoadFileImg_Click(object sender, EventArgs e)
        {
            var traloi = openFileDialogImg.ShowDialog();

            if (traloi == System.Windows.Forms.DialogResult.OK)
            {
                string file = openFileDialogImg.FileName;
                if (string.IsNullOrEmpty(file))
                    return;
                pcbHinhAnh.Image = Image.FromFile(file); 
            }
        }

        void LoadData2(DataTable dtSource)
        {
            try
            {
                dgvSANPHAM.DataSource = dtSource;
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvSANPHAM_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table SanPham. Lỗi rồi!");
            }
        }

        private void TimKiemTheoTentoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tenCanTim = sender as ToolStripTextBox;
                DataTable kq = dbSP.LaySanPhamTheoTimKiem(KieuTimKiemSanPham.THEO_TEN, true, tenCanTim.Text);
                if (kq.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(kq);
            }
        }

        private void TimKiemGiaNhoHontoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tenCanTim = sender as ToolStripTextBox;
                DataTable kq = dbSP.LaySanPhamTheoTimKiem(KieuTimKiemSanPham.THEO_GIA, false, tenCanTim.Text);
                if (kq.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(kq);
            }
        }

        private void TimKiemGiaLonHontoolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tenCanTim = sender as ToolStripTextBox;
                DataTable kq = dbSP.LaySanPhamTheoTimKiem(KieuTimKiemSanPham.THEO_GIA, true, tenCanTim.Text);
                if (kq.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(kq);
            }
        }
    }
}
