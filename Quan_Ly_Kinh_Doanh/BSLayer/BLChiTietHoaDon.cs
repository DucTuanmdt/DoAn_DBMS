using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    class BLChiTietHoaDon
    {
        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã hóa đơn");
            dt.Columns.Add("Tên sản phẩm");
            dt.Columns.Add("Số lượng");
        }
        
        public DataTable LayChiTietHoaDon()
        {

            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var pbs = from p in qlSTEntity.CHITIETHOADONs select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã hóa đơn");
            dt.Columns.Add("Tên sản phẩm");
            dt.Columns.Add("Số lượng");

            foreach (var p in pbs)
            {
                dt.Rows.Add(p.MaHD, p.SANPHAM.TenSP, p.SoLuong);
            }
            return dt;
        }

        public bool ThemChiTietHoaDon(string MaHD, string TenSP, string SoLuong, ref string err)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            CHITIETHOADON pb = new CHITIETHOADON();

            pb.MaHD = MaHD;
            pb.MaSP = LayMaSP(TenSP);
            int soluong = 0;
            int.TryParse(SoLuong, out soluong);
            pb.SoLuong = soluong;

            qlSTEntity.CHITIETHOADONs.Add(pb);
            qlSTEntity.SaveChanges();

            return true;
        }

        public bool CapNhatChiTietHoaDon(string MaHD, string TenSP, string SoLuong, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            string MaSP = LayMaSP(TenSP);
            var pbQuery = (from p in qlKDEntity.CHITIETHOADONs
                           where p.MaHD == MaHD && p.MaSP == MaSP
                           select p).SingleOrDefault();

            if (pbQuery != null)
            {
                int soluong = 0;
                int.TryParse(SoLuong, out soluong);
                pbQuery.SoLuong = soluong;

                qlKDEntity.SaveChanges();
            }

            return true;
        }

        public bool XoaChiTietHoaDon(string MaHD, string MaSP, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            CHITIETHOADON pb = new CHITIETHOADON();
            pb.MaHD = MaHD;
            pb.MaSP = MaSP;

            qlKDEntity.CHITIETHOADONs.Attach(pb);
            qlKDEntity.CHITIETHOADONs.Remove(pb);

            qlKDEntity.SaveChanges();

            return true;
        }

        public List<string> LayDSTenSP()
        {
            List<string> dsMaSP = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.SANPHAMs select p;

            foreach (var item in sps)
            {
                dsMaSP.Add(item.TenSP);
            }

            return dsMaSP;
        }

        string LayMaSP(string TenSP)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = (from p in qlSTEntity.SANPHAMs
                       where p.TenSP.Trim() == TenSP.Trim()
                       select p).SingleOrDefault();
            return sps.MaSP;
        }

        public List<string> LayDSMaHD()
        {
            List<string> dsMaHD = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.HOADONs select p;

            foreach (var item in sps)
            {
                dsMaHD.Add(item.MaHD);
            }

            return dsMaHD;
        }

        public DataTable LayChiTietHoaDonTheoTimKiem(string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();

            var sps = from p in qlSTEntity.CHITIETHOADONs
                      where p.SANPHAM.TenSP.Contains(chuoiCanTim)
                      || chuoiCanTim.Contains(p.SANPHAM.TenSP)
                      select p;

            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaHD, p.SANPHAM.TenSP, p.SoLuong);
            }

            return dt;
        }

    }
}
