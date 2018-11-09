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
            DataTable dt = new DataTable();
            SetTableColumn(dt);
            var khs = qlSTEntity.view_HoaDon.SqlQuery("SELECT * FROM dbo.view_HoaDon");

            foreach (var p in khs)
            {
                dt.Rows.Add(p.MaHD, p.TenKH, p.TenNV, p.NgayLapHD, p.NgayNhanHang);
            }
            return dt;
        }

        public bool ThemHoaDon(string MaHD, string TenKH, string TenNV,
            DateTime NgayLapHD, DateTime NgayNhanHang, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();

                string query = string.Format("EXEC dbo.usp_HoaDon_Them N'{0}', N'{1}', N'{2}', '{3}', '{4}'", MaHD, LayMaKH(TenKH), LayMaNV(TenNV), ChuanHoaNgay(NgayLapHD), ChuanHoaNgay(NgayNhanHang));
                qlSTEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch(Exception e) { }

            return false;
        }

        public bool CapNhatHoaDon(string MaHD, string TenKH, string TenNV,
            DateTime NgayLapHD, DateTime NgayNhanHang, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
                string query = string.Format("EXEC dbo.usp_HoaDon_Sua N'{0}', N'{1}', N'{2}', '{3}', '{4}'", MaHD, LayMaKH(TenKH), LayMaNV(TenNV), ChuanHoaNgay(NgayLapHD), ChuanHoaNgay(NgayNhanHang));
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch(Exception e) { }
            return false;
        }

        public bool XoaHoaDon(string MaHD, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
                string query = string.Format("EXEC dbo.usp_HoaDon_Xoa N'{0}'", MaHD);
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch(Exception e) { }

            return false;
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
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            string mamoi = qlSTEntity.Database.SqlQuery<string>("SELECT dbo.func_HoaDon_SinhMa()").Single().ToString().Trim();
            return mamoi;
        }

        public DataTable LayHoaDonTheoTimKiem(KieuTimKiemHoaDon kieuTimKiem, string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            if (kieuTimKiem == KieuTimKiemHoaDon.THEO_KH)
            {
                var sps = qlSTEntity.func_HoaDon_TimTheoTenKhachHang(chuoiCanTim);
                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaHD, p.TenKH, p.TenNV, p.NgayLapHD, p.NgayNhanHang);
                }
            }
            else
            {
                var sps = qlSTEntity.func_HoaDon_TimTheoTenNhanVien(chuoiCanTim);
                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaHD, p.TenKH, p.TenNV, p.NgayLapHD, p.NgayNhanHang);
                }
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
