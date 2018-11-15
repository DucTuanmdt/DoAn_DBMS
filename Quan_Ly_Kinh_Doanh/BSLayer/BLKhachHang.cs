using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    class BLKhachHang
    {
        private string _conString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["QuanLySieuThiEntities"].ConnectionString; } }

        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã KH");
            dt.Columns.Add("Tên KH");
            dt.Columns.Add("Điện thoại");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Địa chỉ");
            dt.Columns.Add("Giới tính");

        }

        public DataTable LayKhachHang()
        {

            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var khs = qlSTEntity.view_KhachHang.SqlQuery("SELECT * FROM dbo.view_KhachHang");
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in khs)
            {
                dt.Rows.Add(p.MaKH, p.TenKH, p.DienThoai, p.NgaySinh, p.DiaChi, p.GioiTinh);
            }
            return dt;
        }

        public bool ThemKhachHang(string MaKH, string TenKH, string DienThoai,
            DateTime NgaySinh, string DiaChi, string GioiTinh, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXECUTE dbo.usp_KhachHang_Them N'{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}'", MaKH, TenKH, GioiTinh, ChuanHoaNgay(NgaySinh), DiaChi, DienThoai);
                qlSTEntity.Database.ExecuteSqlCommand(query);
                return true;

            } catch (Exception e) { }

            return false;
        }

        public bool CapNhatKhachHang(string MaKH, string TenKH, string DienThoai,
            DateTime NgaySinh, string DiaChi, string GioiTinh, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXECUTE dbo.usp_KhachHang_Sua N'{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}'", MaKH, TenKH, GioiTinh, ChuanHoaNgay(NgaySinh), DiaChi, DienThoai);
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch (Exception e) { }

            return false;
        }

        public bool XoaKhachHang(string MaKH, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXECUTE dbo.usp_KhachHang_Xoa N'{0}'", MaKH);
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch (Exception e) { }

            return false;
        }

        public string SinhMaKHMoi(string MaCuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            string mamoi = qlSTEntity.Database.SqlQuery<string>("SELECT dbo.func_KhachHang_SinhMa()").Single().ToString().Trim();
            return mamoi;
        }

        public DataTable LayKhachHangTheoLoc(bool isLonHon, string Tuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            int tuoi = 0;
            int.TryParse(Tuoi, out tuoi);
            
            if (isLonHon == true)
            {
                var sps = qlSTEntity.func_KhachHang_LocTuoiLonHon(tuoi);
                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaKH, p.TenKH, p.DienThoai, p.NgaySinh, p.DiaChi);
                }
            }
            else
            {
                var sps2 = qlSTEntity.func_KhachHang_LocTuoiNhoHon(tuoi);
                foreach (var p in sps2)
                {
                    dt.Rows.Add(p.MaKH, p.TenKH, p.DienThoai, p.NgaySinh, p.DiaChi);
                }
            }

            return dt;
        }

        public DataTable LayKhachHangTheoTimKiem(string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);

            var sps = qlSTEntity.func_KhachHang_TimTheoTen(chuoiCanTim);

            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaKH, p.TenKH, p.DienThoai, p.NgaySinh, p.DiaChi);
            }

            return dt;
        }

        public string ChuanHoaNgay(DateTime ngay)
        {
            string ngayChuan = ngay.ToString("yyyy/MM/dd");
            return ngayChuan;
        }
    }
}
