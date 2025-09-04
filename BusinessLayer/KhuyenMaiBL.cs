using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLayer
{
    public class KhuyenMaiBL
    {
        private KhuyenMaiDL khuyenMaiDL;
        public KhuyenMaiBL()
        {
            khuyenMaiDL = new KhuyenMaiDL();
        }
        public List<KhuyenMai> GetKhuyenMai()
        {
            try
            {
                return khuyenMaiDL.GetKhuyenMai();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public string GetPhanTram(string maKM)
        {
            try
            {
                return khuyenMaiDL.GetPhanTram(maKM);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<string> GetDanhSachMaKM()
        {
            try
            {
                return khuyenMaiDL.GetDanhSachMaKM();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<KhuyenMai> TimKiemKM(string maKM)
        {
            try
            {
                return khuyenMaiDL.TimKiemKM(maKM);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemKhuyenMai(KhuyenMai km)
        {
            if(string.IsNullOrEmpty(km.PhanTram.ToString()) || string.IsNullOrEmpty(km.MaKM))
                return false;

            return khuyenMaiDL.ThemKhuyenMai(km);
        }
    }
}
