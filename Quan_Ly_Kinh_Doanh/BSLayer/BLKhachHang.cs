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
        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã KH");
            dt.Columns.Add("Tên KH");
            dt.Columns.Add("Điện thoại");
            dt.Columns.Add("Ngày sinh");
            dt.Columns.Add("Địa chỉ");
        }

        public DataTable LayKhachHang()
        {

            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var khs = from p in qlSTEntity.KHACHHANGs select p;
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in khs)
            {
                dt.Rows.Add(p.MaKH, p.TenKH, p.DienThoai, p.NgaySinh, p.DiaChi);
            }
            return dt;
        }

        public bool ThemKhachHang(string MaKH, string TenKH, string DienThoai,
            DateTime NgaySinh, string DiaChi, ref string err)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = MaKH;
            kh.TenKH = TenKH;
            kh.DienThoai = DienThoai;
            kh.NgaySinh = NgaySinh;
            kh.DiaChi = DiaChi;

            qlSTEntity.KHACHHANGs.Add(kh);
            qlSTEntity.SaveChanges();

            return true;
        }

        public bool CapNhatKhachHang(string MaKH, string TenKH, string DienThoai,
            DateTime NgaySinh, string DiaChi, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            var khQuery = (from p in qlKDEntity.KHACHHANGs
                           where p.MaKH == MaKH
                           select p).SingleOrDefault();

            if (khQuery != null)
            {
                khQuery.TenKH = TenKH;
                khQuery.DienThoai = DienThoai;
                khQuery.NgaySinh = NgaySinh;
                khQuery.DiaChi = DiaChi;

                qlKDEntity.SaveChanges();
            }

            return true;
        }

        public bool XoaKhachHang(string MaKH, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            KHACHHANG kh = new KHACHHANG();
            kh.MaKH = MaKH;

            qlKDEntity.KHACHHANGs.Attach(kh);
            qlKDEntity.KHACHHANGs.Remove(kh);

            qlKDEntity.SaveChanges();

            return true;
        }

        public string SinhMaKHMoi(string MaCuoi)
        {
            int mamoi = int.Parse(MaCuoi.Substring(2)) + 1;

            return "KH" + mamoi.ToString("D2");
        }

        public DataTable LayKhachHangTheoLoc(bool isLonHon, string Tuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            IQueryable<KHACHHANG> sps;

            int tuoi = 0;
            int.TryParse(Tuoi, out tuoi);

            DateTime homNay = DateTime.Today;
            homNay = homNay.AddYears(tuoi * -1);

            if (isLonHon == true)
            {
                sps = from p in qlSTEntity.KHACHHANGs
                      where p.NgaySinh <= homNay
                      select p;
            }
            else
            {
                sps = from p in qlSTEntity.KHACHHANGs
                      where p.NgaySinh >= homNay
                      select p;
            }


            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaKH, p.TenKH, p.DienThoai, p.NgaySinh, p.DiaChi);
            }

            return dt;
        }

        public DataTable LayKhachHangTheoTimKiem(string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();

            var sps = from p in qlSTEntity.KHACHHANGs
                      where chuoiCanTim.Contains(p.TenKH) 
                      || p.TenKH.Contains(chuoiCanTim)
                      select p;


            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaKH, p.TenKH, p.DienThoai, p.NgaySinh, p.DiaChi);
            }

            return dt;
        }
    }
}
