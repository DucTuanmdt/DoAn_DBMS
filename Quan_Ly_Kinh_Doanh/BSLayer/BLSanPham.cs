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
            var sps = qlSTEntity.SANPHAMs.SqlQuery("SELECT * FROM dbo.SANPHAM");
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
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();

                byte[] Hinh = null;

                if (HinhSP != null)
                {
                    MemoryStream img = new MemoryStream();
                    HinhSP.Save(img, ImageFormat.Jpeg);
                    Hinh = img.ToArray();
                }

                string query = string.Format("EXECUTE dbo.usp_SanPham_Them N'{0}', N'{1}', N'{2}', '{3}', @Hinh", MaSP, TenSP, DonViTinh, GiaBan);
                qlSTEntity.Database.ExecuteSqlCommand(query, new SqlParameter("@Hinh", Hinh));

                return true;
            }
            catch (Exception e) { }

            return false;
        }   

        public bool CapNhatSanPham(string MaSP, string TenSP, string DonViTinh, string GiaBan, Image HinhSP, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
                byte[] Hinh = null;
                if (HinhSP != null)
                {
                    MemoryStream img = new MemoryStream();
                    HinhSP.Save(img, ImageFormat.Jpeg);
                    Hinh = img.ToArray();
                }
                string query = string.Format("EXEC dbo.usp_SanPham_Sua N'{0}', N'{1}', N'{2}', '{3}', @Hinh", MaSP, TenSP, DonViTinh, GiaBan);
                qlKDEntity.Database.ExecuteSqlCommand(query, new SqlParameter("@Hinh", Hinh));

                return true;

            } catch(Exception e) { }

            return false;
        }

        public bool XoaSanPham(string MaSP, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
                string query = string.Format("EXEC dbo.usp_SanPham_Xoa N'{0}'", MaSP);
                qlKDEntity.Database.ExecuteSqlCommand(query);
                
                return true;
            } catch(Exception e) { }

            return false;
        }

        public string SinhMaSPMoi(string MaCuoi)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            string mamoi = qlSTEntity.Database.SqlQuery<string>("SELECT dbo.func_SanPham_SinhMa()").Single().ToString().Trim();
            return mamoi;
        }

        public DataTable LaySanPhamTheoTimKiem(KieuTimKiemSanPham kieuTimKiem, bool isLonHon, string chuoiCanTim)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            DbSqlQuery<Quan_Ly_Kinh_Doanh.SANPHAM> sps;
            string query = "";
            if (kieuTimKiem == KieuTimKiemSanPham.THEO_TEN)
            {
                query = string.Format("SELECT * FROM dbo.func_SanPham_TimTheoTen(N'{0}')", chuoiCanTim);
            }
            else
            {
                if (isLonHon == true)
                {
                    query = string.Format("SELECT * FROM dbo.func_SanPham_TimGiaLonHon(N'{0}')", chuoiCanTim);
                }
                else
                {
                    query = string.Format("SELECT * FROM dbo.func_SanPham_TimGiaNhoHon(N'{0}')", chuoiCanTim);
                }
            }
            sps = qlSTEntity.SANPHAMs.SqlQuery(query);

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
