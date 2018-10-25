using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    public enum KieuTimKiemPhongBan
    {
        THEO_TEN_PHONG, THEO_TRUONG_PHONG
    }

    class BLPhongBan
    {

        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã phòng");
            dt.Columns.Add("Tên phòng");
            dt.Columns.Add("Trưởng phòng");
        }

        public DataTable LayPhongBan()
        {

            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var pbs = from p in qlSTEntity.PHONGBANs select p;
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in pbs)
            {
                dt.Rows.Add(p.MaPB, p.TenPhong, p.NHANVIEN.Ho.Trim() + " "
                    + p.NHANVIEN.TenLot.Trim() + " " + p.NHANVIEN.Ten.Trim());
            }
            return dt;
        }

        public bool ThemPhongBan(string MaPB, string TenPhong, string TruongPhong, ref string err)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            PHONGBAN pb = new PHONGBAN();

            pb.MaPB = MaPB;
            pb.TenPhong = TenPhong;
            pb.TruongPhong = LayMaNV(TruongPhong);

            qlSTEntity.PHONGBANs.Add(pb);
            qlSTEntity.SaveChanges();

            return true;
        }

        public bool CapNhatPhongBan(string MaPB, string TenPhong, string TruongPhong, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            var pbQuery = (from p in qlKDEntity.PHONGBANs
                           where p.MaPB == MaPB
                           select p).SingleOrDefault();

            if (pbQuery != null)
            {
                pbQuery.TenPhong = TenPhong;
                pbQuery.TruongPhong = LayMaNV(TruongPhong);

                qlKDEntity.SaveChanges();
            }

            return true;
        }

        public bool XoaPhongBan(string MaPB, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            var nvs = (from p in qlKDEntity.NHANVIENs
                       where p.Phong == MaPB
                       select p);
            foreach (var item in nvs)
            {
                qlKDEntity.NHANVIENs.Remove(item);
            }

            PHONGBAN pb = new PHONGBAN();
            pb.MaPB = MaPB;

            qlKDEntity.PHONGBANs.Attach(pb);
            qlKDEntity.PHONGBANs.Remove(pb);

            qlKDEntity.SaveChanges();

            return true;
        }

        public string SinhMaPBMoi(string MaCuoi)
        {
            int mamoi = int.Parse(MaCuoi.Substring(1)) + 1;

            return "P" + mamoi.ToString("D2");
        }

        public List<string> LayDSTenNV()
        {
            List<string> dsTenNV = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.NHANVIENs orderby p.Ten ascending select p;

            foreach (var item in sps)
            {
                dsTenNV.Add(item.Ho.Trim() + " " + item.TenLot.Trim() + " " + item.Ten.Trim());
            }

            return dsTenNV;
        }

        string LayMaNV(string TenNV)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = (from p in qlSTEntity.NHANVIENs
                       where (p.Ho.Trim() + " " + p.TenLot.Trim() + " " + p.Ten.Trim()) == TenNV.Trim()
                       select p).SingleOrDefault();
            return sps.MaNV;
        }

        public DataTable LayPhongBanTheoTimKiem(KieuTimKiemPhongBan kieuTimKiem, string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            IQueryable<PHONGBAN> sps;
            if (kieuTimKiem == KieuTimKiemPhongBan.THEO_TEN_PHONG)
            {
                sps = from p in qlSTEntity.PHONGBANs
                      where chuoiCanTim.Contains(p.TenPhong)
                      || p.TenPhong.Contains(chuoiCanTim)
                      select p;
            }
            else
            {
                sps = from p in qlSTEntity.PHONGBANs
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
                dt.Rows.Add(p.MaPB, p.TenPhong, p.NHANVIEN.Ho.Trim() + " "
                    + p.NHANVIEN.TenLot.Trim() + " " + p.NHANVIEN.Ten.Trim());
            }

            return dt;
        }
    }
}
