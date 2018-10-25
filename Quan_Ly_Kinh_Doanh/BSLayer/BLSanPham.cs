using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    public enum KieuTimKiemSanPham
    {
        THEO_TEN, THEO_GIA
    }

    public class BLSanPham
    {

        void SetTableColumn(DataTable dt)
        {
            dt.Columns.Add("Mã SP");
            dt.Columns.Add("Tên SP");
            dt.Columns.Add("Đơn vị tính");
            dt.Columns.Add("Giá bán");
        }

        public DataTable LaySanPham()
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.SANPHAMs select p;
            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaSP, p.TenSP, p.DonViTinh, p.Gia);
            }
            return dt;
        }

        public Image LayHinhAnhSanPham(string MaSP)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            SANPHAM sp = (from p in qlKDEntity.SANPHAMs
                          where p.MaSP == MaSP
                          select p).FirstOrDefault();

            MemoryStream fileAnh = new MemoryStream(sp.Hinh.ToArray());
            Image img = Image.FromStream(fileAnh);
            return img;
        }

        public bool ThemSanPham(string MaSP, string TenSP, string DonViTinh, string GiaBan, Image HinhSP, ref string err)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            SANPHAM sp = new SANPHAM();
            sp.MaSP = MaSP;
            sp.TenSP = TenSP;
            sp.DonViTinh = DonViTinh;
            float gia = 0;
            float.TryParse(GiaBan, out gia);
            sp.Gia = gia;

            if (HinhSP != null)
            {
                MemoryStream img = new MemoryStream();
                HinhSP.Save(img, ImageFormat.Jpeg);
                sp.Hinh = img.ToArray();
            }
            else
            {
                //Thêm hình mặc định
            }

            qlSTEntity.SANPHAMs.Add(sp);
            qlSTEntity.SaveChanges();

            return true;
        }

        public bool CapNhatSanPham(string MaSP, string TenSP, string DonViTinh, string GiaBan, Image HinhSP, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            var spQuery = (from p in qlKDEntity.SANPHAMs
                           where p.MaSP == MaSP
                           select p).SingleOrDefault();

            if (spQuery != null)
            {
                spQuery.TenSP = TenSP;
                spQuery.DonViTinh = DonViTinh;
                float gia = 0;
                float.TryParse(GiaBan, out gia);
                spQuery.Gia = gia;

                if (HinhSP != null)
                {
                    MemoryStream img = new MemoryStream();
                    HinhSP.Save(img, ImageFormat.Jpeg);
                    spQuery.Hinh = img.ToArray();
                }

                qlKDEntity.SaveChanges();
            }

            return true;
        }

        public bool XoaSanPham(string MaSP, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            var cthds = from p in qlKDEntity.CHITIETHOADONs
                        where p.MaSP == MaSP
                        select p;

            foreach (var item in cthds)
            {
                qlKDEntity.CHITIETHOADONs.Remove(item);
            }

            SANPHAM sp = new SANPHAM();
            sp.MaSP = MaSP;

            qlKDEntity.SANPHAMs.Attach(sp);
            qlKDEntity.SANPHAMs.Remove(sp);

            qlKDEntity.SaveChanges();

            return true;
        }
        
        public string SinhMaSPMoi(string MaCuoi)
        {
            int mamoi = int.Parse(MaCuoi.Substring(2)) + 1;

            return "SP" + mamoi.ToString("D2");
        }

        public DataTable LaySanPhamTheoTimKiem(KieuTimKiemSanPham kieuTimKiem, bool isLonHon, string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            IQueryable<SANPHAM> sps;
            if (kieuTimKiem == KieuTimKiemSanPham.THEO_TEN)
                sps = from p in qlSTEntity.SANPHAMs
                      where chuoiCanTim.Contains(p.TenSP)
                      || p.TenSP.Contains(chuoiCanTim)
                      select p;
            else
            {
                int gia = 0;
                int.TryParse(chuoiCanTim, out gia);

                if (isLonHon == true)
                {
                    sps = from p in qlSTEntity.SANPHAMs
                          where p.Gia > gia
                          select p;
                }
                else
                {
                    sps = from p in qlSTEntity.SANPHAMs
                          where p.Gia < gia
                          select p;
                }
            }

            DataTable dt = new DataTable();
            SetTableColumn(dt);

            foreach (var p in sps)
            {
                dt.Rows.Add(p.MaSP, p.TenSP, p.DonViTinh, p.Gia);
            }

            return dt;
        }

    }
}
