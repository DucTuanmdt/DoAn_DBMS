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
            var pbs = qlSTEntity.CHITIETHOADONs.SqlQuery("SELECT * FROM dbo.CHITIETHOADON");
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in pbs)
            {
                dt.Rows.Add(p.MaHD, p.SANPHAM.TenSP, p.SoLuong);
            }
            return dt;
        }

        public bool ThemChiTietHoaDon(string MaHD, string TenSP, string SoLuong, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
                string query = string.Format("EXEC dbo.usp_ChiTietHoaDon_Them N'{0}', N'{1}', '{2}'", MaHD, LayMaSP(TenSP), SoLuong);
                qlSTEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch (Exception e) { }

            return false;
        }

        public bool CapNhatChiTietHoaDon(string MaHD, string TenSP, string SoLuong, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
                string query = string.Format("EXEC dbo.usp_ChiTietHoaDon_Sua N'{0}', N'{1}', '{2}'", MaHD, LayMaSP(TenSP), SoLuong);
                qlKDEntity.Database.ExecuteSqlCommand(query);
                return true;
            } catch(Exception e) { }
            return false;
        }

        public bool XoaChiTietHoaDon(string MaHD, string TenSP, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
                string query = string.Format("EXEC dbo.usp_ChiTietHoaDon_Xoa N'{0}', N'{1}'", MaHD, LayMaSP(TenSP));
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch(Exception e) { }
            return false;
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
            var sps = qlSTEntity.func_ChiTietHoaDon_TimTheoTenSP(chuoiCanTim);

            DataTable dt = new DataTable();
            SetTableColumn(dt);
 
            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaHD, p.TenSP, p.SoLuong);
            }

            return dt;
        }

    }
}
