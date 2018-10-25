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
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
        }
        BLKhachHang dbKH = new BLKhachHang();
        bool isThem = false;
        string err = "";

        void SetEnableTextBox(bool isEnable)
        {
            txtDiaChi.ReadOnly = !isEnable;
            txtDienThoai.ReadOnly = !isEnable;
            txtMaKH.ReadOnly = !isEnable;
            txtTenKH.ReadOnly = !isEnable;
            dtpNgaySinh.Enabled = isEnable;
        }

        void ResetTextBox()
        {
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtDiaChi.ResetText();
            txtDienThoai.ResetText();
            dtpNgaySinh.ResetText();
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
            dgvKHACHHANG.Enabled = true;
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
                dgvKHACHHANG.DataSource = dbKH.LayKhachHang();
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvKHACHHANG_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table KhachHang. Lỗi rồi!");
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
            dgvKHACHHANG.Enabled = false;
            txtMaKH.ReadOnly = true;
            txtMaKH.Text = dbKH.SinhMaKHMoi(dgvKHACHHANG.Rows[dgvKHACHHANG.Rows.Count - 2].Cells[0].Value.ToString());
            txtTenKH.Focus();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isThem = false;
            dgvKHACHHANG_CellClick(null, null);
            SetThemSua();
            SetEnableTextBox(true);
            txtMaKH.ReadOnly = true;
            txtTenKH.Focus();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string MaKH = txtMaKH.Text;
                var traloi = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Trả lời", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (traloi == System.Windows.Forms.DialogResult.Yes)
                {
                    dbKH.XoaKhachHang(MaKH, ref err);
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
                    BLKhachHang blKH = new BLKhachHang();
                    blKH.ThemKhachHang(txtMaKH.Text, txtTenKH.Text, txtDienThoai.Text,
                        dtpNgaySinh.Value, txtDiaChi.Text, ref err);
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
                    BLKhachHang blKH = new BLKhachHang();
                    blKH.CapNhatKhachHang(txtMaKH.Text, txtTenKH.Text, txtDienThoai.Text,
                        dtpNgaySinh.Value, txtDiaChi.Text, ref err);
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
            dgvKHACHHANG_CellClick(null, null);
        }

        private void FormKhachHang_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        //Cái này dùng kỹ thuật Binding thì hay hơn, nhưng chưa kịp test lỗi nên chưa dùng
        private void dgvKHACHHANG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int r = dgvKHACHHANG.CurrentCell.RowIndex;
            int count = 0;
            txtMaKH.Text = dgvKHACHHANG.Rows[r].Cells[count++].Value.ToString();
            txtTenKH.Text = dgvKHACHHANG.Rows[r].Cells[count++].Value.ToString();
            txtDienThoai.Text = dgvKHACHHANG.Rows[r].Cells[count++].Value.ToString();
            dtpNgaySinh.Value = DateTime.Parse(dgvKHACHHANG.Rows[r].Cells[count++].Value.ToString());
            txtDiaChi.Text = dgvKHACHHANG.Rows[r].Cells[count++].Value.ToString();
        }

        void LoadData2(DataTable dtSource)
        {
            try
            {
                dgvKHACHHANG.DataSource = dtSource;
                //Set mấy cái textbox ở chế độ chỉ xem
                SetEnableTextBox(false);
                SetXem();
                dgvKHACHHANG_CellClick(null, null);
            }
            catch
            {
                MessageBox.Show("Không load được dữ liệu từ Table KhachHang. Lỗi rồi!");
            }
        }

        private void LocTuoiNhoHontoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbKH.LayKhachHangTheoLoc(false, tuoiCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }

        private void LocTuoiLonHontoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tuoiCanTim = sender as ToolStripTextBox;
                DataTable tableNV = dbKH.LayKhachHangTheoLoc(true, tuoiCanTim.Text);
                if (tableNV.Rows.Count < 1)
                {
                    MessageBox.Show("Không tìm thấy kết quả nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                LoadData2(tableNV);
            }
        }

        private void TimTheotentoolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ToolStripTextBox tenCanTim = sender as ToolStripTextBox;
                DataTable kq = dbKH.LayKhachHangTheoTimKiem(tenCanTim.Text);
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
