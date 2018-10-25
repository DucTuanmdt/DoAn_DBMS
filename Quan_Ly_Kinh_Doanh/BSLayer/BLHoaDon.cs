using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    public enum KieuTimKiemHoaDon
    {
        THEO_KH, THEO_NV
    }
    class BLHoaDon
    {

        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã hóa đơn");
            dt.Columns.Add("Tên KH");
            dt.Columns.Add("Tên NV");
            dt.Columns.Add("Ngày lập HD");
            dt.Columns.Add("Ngày nhận hàng");
        }

        public DataTable LayHoaDon()
        {

            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var khs = from p in qlSTEntity.HOADONs select p;
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in khs)
            {
                dt.Rows.Add(p.MaHD, p.KHACHHANG.TenKH, p.NHANVIEN.Ho.Trim() + " "
                    + p.NHANVIEN.TenLot.Trim() + " " + p.NHANVIEN.Ten.Trim()
                    , p.NgayLapHD, p.NgayNhanHang);
            }
            return dt;
        }

        public bool ThemHoaDon(string MaHD, string TenKH, string TenNV,
            DateTime NgayLapHD, DateTime NgayNhanHang, ref string err)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            HOADON kh = new HOADON();
            kh.MaHD = MaHD;
            kh.MaKH = LayMaKH(TenKH);
            kh.MaNV = LayMaNV(TenNV);
            kh.NgayLapHD = NgayLapHD;
            kh.NgayNhanHang = NgayNhanHang;

            qlSTEntity.HOADONs.Add(kh);
            qlSTEntity.SaveChanges();

            return true;
        }

        public bool CapNhatHoaDon(string MaHD, string TenKH, string TenNV,
            DateTime NgayLapHD, DateTime NgayNhanHang, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            var khQuery = (from p in qlKDEntity.HOADONs
                           where p.MaHD == MaHD
                           select p).SingleOrDefault();

            if (khQuery != null)
            {
                khQuery.MaKH = LayMaKH(TenKH);
                khQuery.MaNV = LayMaNV(TenNV);
                khQuery.NgayLapHD = NgayLapHD;
                khQuery.NgayNhanHang = NgayNhanHang;

                qlKDEntity.SaveChanges();
            }

            return true;
        }

        public bool XoaHoaDon(string MaHD, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            var nvs = (from p in qlKDEntity.CHITIETHOADONs
                       where p.MaHD == MaHD
                       select p);
            foreach (var item in nvs)
            {
                qlKDEntity.CHITIETHOADONs.Remove(item);
            }

            HOADON kh = new HOADON();
            kh.MaHD = MaHD;

            qlKDEntity.HOADONs.Attach(kh);
            qlKDEntity.HOADONs.Remove(kh);

            qlKDEntity.SaveChanges();

            return true;
        }

        public List<string> LayDSTenKH()
        {
            List<string> dsMaKH = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.KHACHHANGs select p;

            foreach (var item in sps)
            {
                dsMaKH.Add(item.TenKH);
            }

            return dsMaKH;
        }

        public List<string> LayDSTenNV()
        {
            List<string> dsMaKH = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.NHANVIENs select p;

            foreach (var item in sps)
            {
                dsMaKH.Add(item.Ho.Trim() + " " + item.TenLot.Trim() + " " + item.Ten.Trim());
            }

            return dsMaKH;
        }

        string LayMaKH(string TenKH)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = (from p in qlSTEntity.KHACHHANGs
                       where p.TenKH == TenKH
                       select p).SingleOrDefault();
            return sps.MaKH;
        }

        string LayMaNV(string TenNV)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = (from p in qlSTEntity.NHANVIENs
                       where (p.Ho.Trim() + " " + p.TenLot.Trim() + " " + p.Ten.Trim()) == TenNV.Trim()
                       select p).SingleOrDefault();
            return sps.MaNV;
        }

        public string SinhMaHDMoi(string MaCuoi)
        {
            int mamoi = int.Parse(MaCuoi.Substring(2)) + 1;

            return "HD" + mamoi.ToString("D2");
        }

        public DataTable LayHoaDonTheoTimKiem(KieuTimKiemHoaDon kieuTimKiem, string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            IQueryable<HOADON> sps;
            if (kieuTimKiem == KieuTimKiemHoaDon.THEO_KH)
            {
                sps = from p in qlSTEntity.HOADONs
                      where chuoiCanTim.Contains(p.KHACHHANG.TenKH)
                      || p.KHACHHANG.TenKH.Contains(chuoiCanTim)
                      select p;
            }
            else
            {
                sps = from p in qlSTEntity.HOADONs
                      where chuoiCanTim.Contains(p.NHANVIEN.Ho.Trim() + " "
                    + p.NHANVIEN.TenLot.Trim() + " " + p.NHANVIEN.Ten.Trim())
                      || (p.NHANVIEN.Ho.Trim() + " " + p.NHANVIEN.TenLot.Trim() + " "
                      + p.NHANVIEN.Ten.Trim()).Contains(chuoiCanTim)
                      select p;
            }

            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaHD, p.KHACHHANG.TenKH, p.NHANVIEN.Ho.Trim() + " "
                    + p.NHANVIEN.TenLot.Trim() + " " + p.NHANVIEN.Ten.Trim()
                    , p.NgayLapHD, p.NgayNhanHang);
            }

            return dt;
        }
    }
}
