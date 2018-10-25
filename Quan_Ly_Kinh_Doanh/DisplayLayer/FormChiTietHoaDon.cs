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
    public partial class FormChiTietHoaDon : Form
    {
        public FormChiTietHoaDon()
        {
            InitializeComponent();
        }

        
        BLChiTietHoaDon dbKH = new BLChiTietHoaDon();
        bool isThem = false;
        string err = "";

        void SetEnableTextBox(bool isEnable)
        {
            txtSoLuong.ReadOnly = !isEnable;
            cbbMaHD.Enabled = isEnable;
            cbbTenSP.Enabled = isEnable;
        }

        void ResetTextBox()
        {
            cbbMaHD.ResetText();
            cbbTenSP.ResetText();
            txtSoLuong.ResetText();
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
            dgvCHITIETHOADON.Enabled = true;
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
                dgvCHITIETHOADON.DataSource = dbKH.LayChiTietHoaDon();
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvCHITIETHOADON_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table ChiTietHoaDon. Lỗi rồi!");
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
            dgvCHITIETHOADON.Enabled = false;
            cbbMaHD.Focus();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThem = false;
            dgvCHITIETHOADON_CellClick(null, null);
            SetThemSua();
            SetEnableTextBox(true);
            cbbMaHD.Enabled = false;
            cbbTenSP.Enabled = false;
            txtSoLuong.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = cbbMaHD.Text;
                string MaSP = cbbTenSP.Text;
                var traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == System.Windows.Forms.DialogResult.Yes)
                {
                    dbKH.XoaChiTietHoaDon(MaKH, MaSP, ref err);
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
                    BLChiTietHoaDon blKH = new BLChiTietHoaDon();
                    blKH.ThemChiTietHoaDon(cbbMaHD.Text, cbbTenSP.Text, txtSoLuong.Text, ref err);
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
                    BLChiTietHoaDon blKH = new BLChiTietHoaDon();
                    blKH.CapNhatChiTietHoaDon(cbbMaHD.Text, cbbTenSP.Text, txtSoLuong.Text, ref err);
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
            dgvCHITIETHOADON_CellClick(null, null);
        }

        private void FormChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
            KhoiTaoGiaTriComboBox();
        }

        //Cái này dùng kỹ thuật Binding thì hay hơn, nhưng chưa kịp test lỗi nên chưa dùng
        private void dgvCHITIETHOADON_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvCHITIETHOADON.CurrentCell.RowIndex;
            int count = 0;
            cbbMaHD.Text = dgvCHITIETHOADON.Rows[r].Cells[count++].Value.ToString();
            cbbTenSP.Text = dgvCHITIETHOADON.Rows[r].Cells[count++].Value.ToString();
            txtSoLuong.Text = dgvCHITIETHOADON.Rows[r].Cells[count++].Value.ToString();
        }

        void KhoiTaoGiaTriComboBox()
        {
            cbbMaHD.DataSource = dbKH.LayDSMaHD();
            cbbTenSP.DataSource = dbKH.LayDSTenSP();
        }

        void LoadData2(DataTable dtSource)
        {
            try
            {
                KhoiTaoGiaTriComboBox();
                dgvCHITIETHOADON.DataSource = dtSource;
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvCHITIETHOADON_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table KhachHang. Lỗi rồi!");
            }
        }

        private void TimKiemTenSPtoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tenCanTim = sender as ToolStripTextBox;
                DataTable kq = dbKH.LayChiTietHoaDonTheoTimKiem(tenCanTim.Text);
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
