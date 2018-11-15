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
        private string _conString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["QuanLySieuThiEntities"].ConnectionString; } }

        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã phòng");
            dt.Columns.Add("Tên phòng");
            dt.Columns.Add("Trưởng phòng");
        }

        public DataTable LayPhongBan()
        {

            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var pbs = qlSTEntity.view_PhongBan.SqlQuery("SELECT * FROM dbo.view_PhongBan");

            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in pbs)
            {
                dt.Rows.Add(p.MaPB, p.TenPhong, p.TenTruongPhong);
            }
            return dt;
        }

        public bool ThemPhongBan(string MaPB, string TenPhong, string TruongPhong, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXEC dbo.usp_PhongBan_Them N'{0}', N'{1}', N'{2}'", MaPB, TenPhong, LayMaNV(TruongPhong));
                qlSTEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch(Exception e) { }
            return false;
        }

        public bool CapNhatPhongBan(string MaPB, string TenPhong, string TruongPhong, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXEC dbo.usp_PhongBan_Sua N'{0}', N'{1}', N'{2}'", MaPB, TenPhong, LayMaNV(TruongPhong));
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            } catch(Exception e) { }
            return false;
        }

        public bool XoaPhongBan(string MaPB, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXEC dbo.usp_PhongBan_Xoa N'{0}'", MaPB);
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            }catch(Exception e) { }

            return false;
        }

        public string SinhMaPBMoi(string MaCuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            string mamoi = qlSTEntity.Database.SqlQuery<string>("SELECT dbo.func_PhongBan_SinhMa()").Single().ToString().Trim();
            return mamoi;
        }

        public List<string> LayDSTenNV()
        {
            List<string> dsTenNV = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var sps = from p in qlSTEntity.NHANVIENs orderby p.Ten ascending select p;

            foreach (var item in sps)
            {
                dsTenNV.Add(item.Ho.Trim() + " " + item.TenLot.Trim() + " " + item.Ten.Trim());
            }

            return dsTenNV;
        }

        string LayMaNV(string TenNV)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var sps = (from p in qlSTEntity.NHANVIENs
                       where (p.Ho.Trim() + " " + p.TenLot.Trim() + " " + p.Ten.Trim()) == TenNV.Trim()
                       select p).SingleOrDefault();
            return sps.MaNV;
        }

        public DataTable LayPhongBanTheoTimKiem(KieuTimKiemPhongBan kieuTimKiem, string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            DataTable dt = new DataTable();
            SetTableColumn(dt);
            if (kieuTimKiem == KieuTimKiemPhongBan.THEO_TEN_PHONG)
            {
                var sps = qlSTEntity.func_PhongBan_TimTheoTenPhong(chuoiCanTim);
                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaPB, p.TenPhong, p.TenTruongPhong);
                }
            }
            else
            {
                var sps2 = qlSTEntity.func_PhongBan_TimTheoTenTruongPhong(chuoiCanTim);
                foreach (var p in sps2)
                {
                    dt.Rows.Add(p.MaPB, p.TenPhong, p.TenTruongPhong);
                }
            }

            return dt;
        }
    }
}
