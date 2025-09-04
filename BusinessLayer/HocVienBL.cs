using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HocVienBL
    {
        HocVienDL hocvienDL;
        public HocVienBL()
        {
            hocvienDL = new HocVienDL();
        }
        public List<HocVien> GetHocVien()
        {
            try
            {
                return hocvienDL.GetHocVien().ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HocVien> GetHocVienTheoMaPH(string maPH)
        {
            try
            {
                return hocvienDL.GetHocVienTheoMaPH(maPH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HocVien> TimKiemHocVien(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return hocvienDL.TimKiemHocVien(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemHocVien(HocVien hv)
        {

            if (string.IsNullOrWhiteSpace(hv.MaPH) ||
                string.IsNullOrWhiteSpace(hv.HoTen) ||
                string.IsNullOrWhiteSpace(hv.GioiTinh) ||
                string.IsNullOrWhiteSpace(hv.HocLuc) ||
                hv.NgaySinh.Date == DateTime.Now.Date)
            {
                return false;
            }
            else
            {
                return hocvienDL.ThemHocVien(hv);
            }
        }
        public bool CapNhatHocVien(HocVien hv)
        {
            if (string.IsNullOrWhiteSpace(hv.MaPH) ||
                string.IsNullOrWhiteSpace(hv.HoTen) ||
                string.IsNullOrWhiteSpace(hv.GioiTinh) ||
                string.IsNullOrWhiteSpace(hv.HocLuc) ||
                hv.NgaySinh.Date == DateTime.Now.Date)
            {
                return false;
            }
            else
            {
                return hocvienDL.CapNhatHocVien(hv);
            }
        }
    }
}
