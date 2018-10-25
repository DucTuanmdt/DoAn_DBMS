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
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLST.TTNV' table. You can move, or remove it, as needed.
            this.TTNVTableAdapter.Fill(this.QLST.TTNV, "NV01");
            this.HOADONTableAdapter.FillBy(this.QLST.HOADON, "HD01");
            this.reportViewerCTHD.RefreshReport();
            // TODO: This line of code loads data into the 'QLST.CHITIETHOADON' table. You can move, or remove it, as needed.
            this.CHITIETHOADONTableAdapter.Fill(this.QLST.CHITIETHOADON);
            // TODO: This line of code loads data into the 'QLST.NHANVIEN' table. You can move, or remove it, as needed.
            this.NHANVIENTableAdapter.Fill(this.QLST.NHANVIEN);

            this.reportViewerNV.RefreshReport();
            this.reportViewerHD.RefreshReport();
            this.reportViewerCTNV.RefreshReport();


            // đổ data vào combo box
            QLST.NHANVIENDataTable dt = new Quan_Ly_Kinh_Doanh.QLST.NHANVIENDataTable();
            QLSTTableAdapters.NHANVIENTableAdapter da = new QLSTTableAdapters.NHANVIENTableAdapter();
            da.Fill(dt);

            cbbTenNV.DataSource = dt;
            cbbTenNV.DisplayMember = "HoTenNV";
            cbbTenNV.ValueMember = "MaNV";
            cbbTenNV.ResetText();

            QLST.HOADON_DBDataTable dt2 = new QLST.HOADON_DBDataTable();
            QLSTTableAdapters.HOADON_DBTableAdapter da2 = new QLSTTableAdapters.HOADON_DBTableAdapter();
            da2.Fill(dt2);

            cbbHoaDon.DataSource = dt2;
            cbbHoaDon.DisplayMember = "MaHD";
            cbbHoaDon.ValueMember = "MaHD";

            cbbHoaDon.ResetText();

            cbbMaHD.DataSource = dt2;
            cbbMaHD.DisplayMember = "MaHD";
            cbbMaHD.ValueMember = "MaHD";

            cbbNV.DataSource = dt;
            cbbNV.DisplayMember = "HoTenNV";
            cbbNV.ValueMember = "MaNV";
        }

        private void search_NV_Click(object sender, EventArgs e)
        {
            this.NHANVIENTableAdapter.FillBy(this.QLST.NHANVIEN, cbbTenNV.SelectedValue.ToString());
            this.reportViewerNV.RefreshReport();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.NHANVIENTableAdapter.Fill(this.QLST.NHANVIEN);

            this.reportViewerNV.RefreshReport();

            cbbTenNV.ResetText();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.NHANVIENTableAdapter.Fill(this.QLST.NHANVIEN);
            this.reportViewerNV.RefreshReport();
            cbbTenNV.ResetText();

            this.CHITIETHOADONTableAdapter.Fill(this.QLST.CHITIETHOADON);
            this.reportViewerHD.RefreshReport();
            cbbHoaDon.ResetText();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.CHITIETHOADONTableAdapter.FillBy(this.QLST.CHITIETHOADON, cbbHoaDon.Text.Trim());
            this.reportViewerHD.RefreshReport();
        }

        private void btnReload2_Click(object sender, EventArgs e)
        {
            this.CHITIETHOADONTableAdapter.Fill(this.QLST.CHITIETHOADON);
            this.reportViewerHD.RefreshReport();
            cbbHoaDon.ResetText();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            this.HOADONTableAdapter.FillBy(this.QLST.HOADON, cbbMaHD.Text.Trim());
            this.reportViewerCTHD.RefreshReport();
        }

        private void btn_XEM_Click(object sender, EventArgs e)
        {
            this.TTNVTableAdapter.Fill(this.QLST.TTNV, cbbNV.SelectedValue.ToString());
            this.reportViewerCTNV.RefreshReport();
        }

    }
}
