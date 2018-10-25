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
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            //var sps = from p in qlSTEntity.NHANVIENs select p;
            var sps = qlSTEntity.NHANVIENs.SqlQuery("Select * from NhanVien");
            DataTable dt = new DataTable();
            SetTableColumn(dt);
            
            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten, 
                    p.NgaySinh, p.GioiTinh, p.PHONGBAN.TenPhong, p.LuongCB, p.DienThoai);
            }
           
            return dt;
        }

        public Image LayHinhAnhNhanVien(string MaNV)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            NHANVIEN sp = (from p in qlKDEntity.NHANVIENs
                          where p.MaNV == MaNV
                          select p).FirstOrDefault();
            try
            {
                MemoryStream fileAnh = new MemoryStream(sp.Hinh.ToArray());
                Image img = Image.FromStream(fileAnh);
                return img;
            }
            catch
            {
                return null;
            }
        }

        public bool ThemNhanVien(string MaNV, string Ho, string TenLot, string Ten,
            DateTime NgaySinh, string GioiTinh, string Phong, string LuongCB, string DienThoai, Image HinhSP, ref string err)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            NHANVIEN nv = new NHANVIEN();
            nv.MaNV = MaNV;
            nv.Ho = Ho;
            nv.TenLot = TenLot;
            nv.Ten = Ten;
            nv.NgaySinh = NgaySinh;
            nv.GioiTinh = GioiTinh;
            nv.Phong = LayMaPhong(Phong);
            nv.DienThoai = DienThoai;
            
            float luong = 0;
            float.TryParse(LuongCB, out luong);
            nv.LuongCB = luong;

            if (HinhSP != null)
            {
                MemoryStream img = new MemoryStream();
                HinhSP.Save(img, ImageFormat.Jpeg);
                nv.Hinh = img.ToArray();
            }
            else
            {
                //Thêm hình mặc định
            }

            qlSTEntity.NHANVIENs.Add(nv);
            qlSTEntity.SaveChanges();

            return true;
        }

        public bool CapNhatNhanVien(string MaNV, string Ho, string TenLot, string Ten,
            DateTime NgaySinh, string GioiTinh, string Phong, string LuongCB, string DienThoai, Image HinhSP, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            var nvQuery = (from p in qlKDEntity.NHANVIENs
                           where p.MaNV == MaNV
                           select p).SingleOrDefault();

            if (nvQuery != null)
            {
                nvQuery.Ho = Ho;
                nvQuery.TenLot = TenLot;
                nvQuery.Ten = Ten;
                nvQuery.NgaySinh = NgaySinh;
                nvQuery.GioiTinh = GioiTinh;
                nvQuery.Phong = LayMaPhong(Phong);
                nvQuery.DienThoai = DienThoai;

                float gia = 0;
                float.TryParse(LuongCB, out gia);
                nvQuery.LuongCB = gia;

                if (HinhSP != null)
                {
                    MemoryStream img = new MemoryStream();
                    HinhSP.Save(img, ImageFormat.Jpeg);
                    nvQuery.Hinh = img.ToArray();
                }

                qlKDEntity.SaveChanges();
            }

            return true;
        }

        public bool XoaNhanVien(string MaNV, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            var hds = (from p in qlKDEntity.HOADONs
                       where p.MaNV == MaNV
                       select p);
            foreach (var item in hds)
            {
                qlKDEntity.HOADONs.Remove(item);
            }

            var dns = (from p in qlKDEntity.DANGNHAPs
                       where p.MaNV == MaNV
                       select p);

            foreach (var item in dns)
            {
                qlKDEntity.DANGNHAPs.Remove(item);
            }

            NHANVIEN nv = new NHANVIEN();
            nv.MaNV = MaNV;

            qlKDEntity.NHANVIENs.Attach(nv);
            qlKDEntity.NHANVIENs.Remove(nv);

            qlKDEntity.SaveChanges();

            return true;
        }

        public DataTable LayNhanVienTheoSapXep(KieuSapXepNhanVien kieuSapXep, bool isTang)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();

            IOrderedQueryable<NHANVIEN> sps;
            if (isTang == true)
            {
                switch (kieuSapXep)
                {
                    case KieuSapXepNhanVien.THEO_TEN:
                    sps = from p in qlSTEntity.NHANVIENs orderby p.Ten ascending select p;
                    break;

                    case KieuSapXepNhanVien.THEO_LUONG:
                    sps = from p in qlSTEntity.NHANVIENs orderby p.LuongCB ascending select p;
                    break;

                    default:
                    sps = from p in qlSTEntity.NHANVIENs orderby p.NgaySinh descending select p;
                    break;
                }
            }
            else
            {
                switch (kieuSapXep)
                {
                    case KieuSapXepNhanVien.THEO_TEN:
                        sps = from p in qlSTEntity.NHANVIENs orderby p.Ten descending select p;
                        break;

                    case KieuSapXepNhanVien.THEO_LUONG:
                        sps = from p in qlSTEntity.NHANVIENs orderby p.LuongCB descending select p;
                        break;

                    default:
                        sps = from p in qlSTEntity.NHANVIENs orderby p.NgaySinh ascending select p;
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
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            IQueryable<NHANVIEN> sps;
            if (kieuTimKiem == KieuTimKiemNhanVien.THEO_TEN)
                sps = from p in qlSTEntity.NHANVIENs 
                      where p.Ho.Contains(chuoiCanTim) || chuoiCanTim.Contains(p.Ho)
                      || p.TenLot.Contains(chuoiCanTim) || chuoiCanTim.Contains(p.TenLot)
                      || p.Ten.Contains(chuoiCanTim) || chuoiCanTim.Contains(p.Ten)
                      select p;
            else
                sps = from p in qlSTEntity.NHANVIENs where p.MaNV.Contains(chuoiCanTim) 
                      select p;
            
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaNV, p.Ho, p.TenLot, p.Ten,
                    p.NgaySinh, p.GioiTinh, p.Phong, p.LuongCB, p.DienThoai);
            }

            return dt;
        }

        public DataTable LayNhanVienTheoLoc(KieuLocNhanVien kieuLoc, bool isLonHon, string Tuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            IQueryable<NHANVIEN> sps;

            if (kieuLoc == KieuLocNhanVien.THEO_NAM)
                sps = from p in qlSTEntity.NHANVIENs
                      where p.GioiTinh == "Nam"
                      select p;
            else if (kieuLoc == KieuLocNhanVien.THEO_NU)
                sps = from p in qlSTEntity.NHANVIENs
                      where p.GioiTinh == "Nữ"
                      select p;
            else 
            {
                int tuoi = 0;
                int.TryParse(Tuoi, out tuoi);

                DateTime homNay = DateTime.Today;
                homNay.AddYears(tuoi * -1);

                if (isLonHon == true)
                {
                    sps = from p in qlSTEntity.NHANVIENs
                          where p.NgaySinh <= homNay
                          select p;
                }
                else
                {
                    sps = from p in qlSTEntity.NHANVIENs
                          where p.NgaySinh >= homNay
                          select p;
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

        public List<string> LayDSTenPhong()
        {
            List<string> dsTenPhong = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.PHONGBANs select p;
            
            foreach (var item in sps)
            {
                dsTenPhong.Add(item.TenPhong);
            }

            return dsTenPhong;
        }

        string LayMaPhong(string TenPhong)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = (from p in qlSTEntity.PHONGBANs 
                       where p.TenPhong == TenPhong 
                       select p).SingleOrDefault();
            return sps.MaPB;
        }

        public string SinhMaNVMoi(string MaCuoi)
        {
            int mamoi = int.Parse(MaCuoi.Substring(2)) + 1;

            return "NV" + mamoi.ToString("D2");
        }
    }
}
