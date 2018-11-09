using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    class BLDangNhap
    {
        public DataTable LayDangNhap()
        {

            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var pbs = from p in qlSTEntity.DANGNHAPs select p;
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã NV");
            dt.Columns.Add("Mật khẩu");

            foreach (var p in pbs)
            {
                dt.Rows.Add(p.MaNV.Trim(), CheMatKhau(p.MatKhau.Trim()));
            }
            return dt;
        }

        //string HienQuyen(int quyen)
        //{
        //    if (quyen == 1)
        //        return "Admin";
        //    else if (quyen == 2)
        //        return "Moderator";
        //    return "Nhân viên";
        //}

        string CheMatKhau(string MatKhau)
        {
            string str = "";

            foreach (var item in MatKhau)
            {
                str += "✱";
            }
            return str;
        }

        public bool ThemDangNhap(string MaNV, string MatKhau, ref string err)
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            DANGNHAP pb = new DANGNHAP();

            pb.MaNV = MaNV;
            pb.MatKhau = MatKhau;

            qlSTEntity.DANGNHAPs.Add(pb);
            qlSTEntity.SaveChanges();

            return true;
        }

        public bool CapNhatDangNhap(string MaNV, string MatKhau, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();
            var pbQuery = (from p in qlKDEntity.DANGNHAPs
                           where (p.MaNV == MaNV)
                           select p).SingleOrDefault();

            if (pbQuery != null)
            {
                pbQuery.MatKhau = MatKhau;

                qlKDEntity.SaveChanges();
            }

            return true;
        }

        public bool XoaDangNhap(string MaNV, ref string err)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            DANGNHAP pb = new DANGNHAP();
            pb.MaNV = MaNV;

            qlKDEntity.DANGNHAPs.Attach(pb);
            qlKDEntity.DANGNHAPs.Remove(pb);

            qlKDEntity.SaveChanges();

            return true;
        }

        public bool KiemTraDangNhap(string MaNV, string MatKhau)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities();

            var dnQuery = (from p in qlKDEntity.DANGNHAPs
                           where p.MaNV == MaNV && p.MatKhau == MatKhau
                           select p).SingleOrDefault();

            if (dnQuery != null)
                return true;

            return false;
        }

        public List<string> LayDSMaNV()
        {
            List<string> dsMaKH = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities();
            var sps = from p in qlSTEntity.NHANVIENs select p;

            foreach (var item in sps)
            {
                dsMaKH.Add(item.MaNV.Trim());
            }

            return dsMaKH;
        }
    }
}
