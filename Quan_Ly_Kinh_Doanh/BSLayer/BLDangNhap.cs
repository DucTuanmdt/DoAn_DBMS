using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quan_Ly_Kinh_Doanh.BSLayer
{
    class BLDangNhap
    {
        private string _conString { get { return System.Configuration.ConfigurationManager.ConnectionStrings["QuanLySieuThiEntities"].ConnectionString; } }
        private string currentUsername { get { return Properties.Settings.Default.Username; } }

        public DataTable LayDangNhap()
        {
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var pbs = qlSTEntity.DANGNHAPs.SqlQuery("SELECT * FROM dbo.DANGNHAP");
            DataTable dt = new DataTable();
            dt.Columns.Add("Username");
            dt.Columns.Add("Mật khẩu");
            dt.Columns.Add("Quyền hạn");

            foreach (var p in pbs)
            {
                dt.Rows.Add(p.Username.Trim(), CheMatKhau(p.MatKhau.Trim()), p.PhanQuyen);
            }
            return dt;
        }


        string CheMatKhau(string MatKhau)
        {
            string str = "";

            foreach (var item in MatKhau)
            {
                str += "✱";
            }
            return str;
        }

        public bool ThemDangNhap(string Username, string MatKhau, string PhanQuyen, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXEC dbo.usp_DangNhap_Them N'{0}', N'{1}', N'{2}'", Username, MatKhau, PhanQuyen);
                qlSTEntity.Database.ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception e) { }

            return false;
        }

        public bool CapNhatDangNhap(string Username, string MatKhau, string PhanQuyen, ref string err)
        {
            try
            {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXEC dbo.usp_DangNhap_Sua N'{0}', N'{1}', N'{2}'", Username, MatKhau, PhanQuyen);
                qlSTEntity.Database.ExecuteSqlCommand(query);

                if (currentUsername == Username)
                    DoiConnectionString(MatKhau);

                return true;
            }
            catch (Exception e) { }

            return false;
        }

        public bool XoaDangNhap(string Username, ref string err)
        {
            if (currentUsername == Username)
                return false;

                try
                {
                QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
                string query = string.Format("EXEC dbo.usp_DangNhap_Xoa N'{0}'", Username);
                qlSTEntity.Database.ExecuteSqlCommand(query);

                return true;
            }
            catch (Exception e) { }

            return false;
        }

        public bool KiemTraDangNhap(string MaNV, string MatKhau)
        {
            QuanLySieuThiEntities qlKDEntity = new QuanLySieuThiEntities(_conString);

            //var dnQuery = (from p in qlKDEntity.DANGNHAPs
            //               where p.MaNV == MaNV && p.MatKhau == MatKhau
            //               select p).SingleOrDefault();

            //if (dnQuery != null)
            //    return true;

            return false;
        }

        public List<string> LayDSMaNV()
        {
            List<string> dsMaKH = new List<string>();
            QuanLySieuThiEntities qlSTEntity = new QuanLySieuThiEntities(_conString);
            var sps = from p in qlSTEntity.NHANVIENs select p;

            foreach (var item in sps)
            {
                dsMaKH.Add(item.MaNV.Trim());
            }

            return dsMaKH;
        }

        public void DoiConnectionString(string MatKKhau)
        {
            string newConnectionString = _conString;
            int startIndex = _conString.IndexOf("password");
            int endIndex = _conString.IndexOf(";", startIndex);
            string oldPass = newConnectionString.Substring(startIndex, endIndex - startIndex);
            string newPass = string.Format("password={0}", MatKKhau);

            newConnectionString = newConnectionString.Replace(oldPass, newPass);

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringsSection.ConnectionStrings["QuanLySieuThiEntities"].ConnectionString = newConnectionString;
            config.Save();
            ConfigurationManager.RefreshSection("connectionStrings");
        }
    }
}
