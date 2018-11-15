using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    public enum KieuSapXepNhanVien
    {
        THEO_TEN, THEO_LUONG, THEO_TUOI
    }

    public enum KieuTimKiemNhanVien
    {
        THEO_TEN, THEO_ID
    }

    public enum KieuLocNhanVien
    {
        THEO_NAM, THEO_NU, THEO_TUOI
    }

    class BLNhanVien
    {
        private string _conString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["QuanLySieuThiEntities"].ConnectionString; } }

        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Họ");
            dt.Columns.Add("Tên lót");
            dt.Columns.Add("Tên");
            dt.Columns.Add("Ngày Sinh");
            dt.Columns.Add("Giới tính");
            dt.Columns.Add("Phòng ban");
            dt.Columns.Add("Lương cơ bản");
            dt.Columns.Add("Điện thoại");
        }

        public DataTable LayNhanVien()
        {
            DataTable dt = new DataTable();
            SetTableColumn(dt);
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
                var sps = qlSTEntity.view_NhanVien.SqlQuery("SELECT * FROM dbo.view_NhanVien");

                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                        p.NgaySinh, p.GioiTinh, p.TenPhong, p.LuongCB, p.DienThoai);
                }
            }
            catch (Exception e) { }

            return dt;
        }

        public Image LayHinhAnhNhanVien(string MaNV)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);
            NHANVIEN sp = (from p in qlKDEntity.NHANVIENs
                           where p.MaNV == MaNV
                           select p).FirstOrDefault();
            try
            {
                MemoryStream fileAnh = new MemoryStream(sp.Hinh.ToArray());
                Image img = Image.FromStream(fileAnh);
                return img;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool ThemNhanVien(string MaNV, string Ho, string TenLot, string Ten,
            DateTime NgaySinh, string GioiTinh, string Phong, string LuongCB, string DienThoai, Image HinhSP, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
                byte[] Hinh = null;
                if (HinhSP != null)
                {
                    MemoryStream img = new MemoryStream();
                    HinhSP.Save(img, ImageFormat.Jpeg);
                    Hinh = img.ToArray();
                }
                string query = string.Format("EXEC dbo.usp_NhanVien_Them N'{0}', N'{1}', N'{2}', N'{3}', '{4}', N'{5}', N'{6}', '{7}', @Hinh, N'{8}'", MaNV, Ho, TenLot, Ten, ChuanHoaNgay(NgaySinh), GioiTinh, LayMaPhong(Phong), LuongCB, DienThoai);
                qlSTEntity.Database.ExecuteSqlCommand(query, new SqlParameter("@Hinh", Hinh));

                return true;
            }
            catch (Exception e) { }

            return false;
        }

        public bool CapNhatNhanVien(string MaNV, string Ho, string TenLot, string Ten,
            DateTime NgaySinh, string GioiTinh, string Phong, string LuongCB, string DienThoai, Image HinhSP, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);
                byte[] Hinh = null;
                if (HinhSP != null)
                {
                    MemoryStream img = new MemoryStream();
                    HinhSP.Save(img, ImageFormat.Jpeg);
                    Hinh = img.ToArray();
                }
                string query = string.Format("EXEC dbo.usp_NhanVien_Sua N'{0}', N'{1}', N'{2}', N'{3}', '{4}', N'{5}', N'{6}', '{7}', @Hinh, N'{8}'", MaNV, Ho, TenLot, Ten, ChuanHoaNgay(NgaySinh), GioiTinh, LayMaPhong(Phong), LuongCB, DienThoai);
                qlKDEntity.Database.ExecuteSqlCommand(query, new SqlParameter("@Hinh", Hinh));

                return true;
            }
            catch (Exception e) { }

            return false;
        }

        public bool XoaNhanVien(string MaNV, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXEC dbo.usp_NhanVien_Xoa N'{0}'", MaNV);
                qlKDEntity.Database.ExecuteSqlCommand(query);

                return true;
            }
            catch (Exception e) { }

            return false;

        }

        public DataTable LayNhanVienTheoSapXep(KieuSapXepNhanVien kieuSapXep, bool isTang)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);

            DbSqlQuery<Quan_Ly_Kinh_Doanh.NHANVIEN> sps;
            if (isTang == true)
            {
                switch (kieuSapXep)
                {
                    case KieuSapXepNhanVien.THEO_TEN:
                        sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT * FROM dbo.NHANVIEN ORDER BY Ten ASC");
                        break;

                    case KieuSapXepNhanVien.THEO_LUONG:
                        sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT *FROM NHANVIEN ORDER BY LuongCB ASC");
                        break;

                    default:
                        sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT * FROM dbo.NHANVIEN ORDER BY NgaySinh DESC");
                        break;
                }
            }
            else
            {
                switch (kieuSapXep)
                {
                    case KieuSapXepNhanVien.THEO_TEN:
                        sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT * FROM dbo.NHANVIEN ORDER BY Ten DESC");
                        break;

                    case KieuSapXepNhanVien.THEO_LUONG:
                        sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT *FROM NHANVIEN ORDER BY LuongCB DESC");
                        break;

                    default:
                        sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT * FROM dbo.NHANVIEN ORDER BY NgaySinh ASC");
                        break;
                }
            }

            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                    p.NgaySinh, p.GioiTinh, p.Phong, p.LuongCB, p.DienThoai);
            }

            return dt;
        }

        public DataTable LayNhanVienTheoTimKiem(KieuTimKiemNhanVien kieuTimKiem, string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            DataTable dt = new DataTable();
            SetTableColumn(dt);
            try
            {
                System.Data.Entity.Infrastructure.DbSqlQuery<Quan_Ly_Kinh_Doanh.NHANVIEN> sps;
                if (kieuTimKiem == KieuTimKiemNhanVien.THEO_TEN)
                    sps = qlSTEntity.NHANVIENs.SqlQuery("Select * from func_NhanVien_TimTheoTen('" + chuoiCanTim + "')");
                else
                    sps = qlSTEntity.NHANVIENs.SqlQuery("Select * from func_NhanVien_TimTheoID('" + chuoiCanTim + "')");

                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                        p.NgaySinh, p.GioiTinh, p.Phong, p.LuongCB, p.DienThoai);
                }
            } catch(Exception e) { }

            return dt;
        }

        public DataTable LayNhanVienTheoLoc(KieuLocNhanVien kieuLoc, bool isLonHon, string Tuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            DbSqlQuery<Quan_Ly_Kinh_Doanh.NHANVIEN> sps;
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            if (kieuLoc == KieuLocNhanVien.THEO_NAM)
            {
                sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT * FROM dbo.view_NhanVien_Nam");
                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                        p.NgaySinh, p.GioiTinh, p.Phong, p.LuongCB, p.DienThoai);
                }
            }
            else if (kieuLoc == KieuLocNhanVien.THEO_NU)
            {
                sps = qlSTEntity.NHANVIENs.SqlQuery("SELECT * FROM dbo.view_NhanVien_Nu");
                foreach (var p in sps)
                {
                    dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                        p.NgaySinh, p.GioiTinh, p.Phong, p.LuongCB, p.DienThoai);
                }
            }
            else
            {
                int tuoi = 0;
                int.TryParse(Tuoi, out tuoi);

                if (isLonHon == true)
                {
                    var sps2 = qlSTEntity.func_NhanVien_LocTuoiLonHon(tuoi);

                    foreach (var p in sps2)
                    {
                        dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                            p.NgaySinh, p.GioiTinh, p.Phong, p.LuongCB, p.DienThoai);
                    }
                }
                else
                {
                    var sps3 = qlSTEntity.func_NhanVien_LocTuoiNhoHon(tuoi);

                    foreach (var p in sps3)
                    {
                        dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                            p.NgaySinh, p.GioiTinh, p.Phong, p.LuongCB, p.DienThoai);
                    }
                }

            }

            return dt;
        }

        public List<string> LayDSTenPhong()
        {
            List<string> dsTenPhong = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var sps = from p in qlSTEntity.PHONGBANs select p;

            foreach (var item in sps)
            {
                dsTenPhong.Add(item.TenPhong);
            }

            return dsTenPhong;
        }

        string LayMaPhong(string TenPhong)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var sps = (from p in qlSTEntity.PHONGBANs
                       where p.TenPhong == TenPhong
                       select p).SingleOrDefault();
            return sps.MaPB;
        }

        public string SinhMaNVMoi(string MaCuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            string mamoi = qlSTEntity.Database.SqlQuery<string>("SELECT dbo.func_NhanVien_SinhMa()").Single().ToString().Trim();
            return mamoi;
        }

        public string ChuanHoaNgay(DateTime ngay)
        {
            string ngayChuan = ngay.ToString("yyyy/MM/dd");
            return ngayChuan;
        }
    }
}
