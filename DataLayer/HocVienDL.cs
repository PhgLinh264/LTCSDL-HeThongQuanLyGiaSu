using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HocVienDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public HocVienDL()
        {
            
        }
        public List<HocVien> GetHocVien()
        {
            try
            {
                return db.HocViens.ToList();
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
                return db.HocViens.Where(hv => hv.MaPH == maPH).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HocVien> TimKiemHocVien(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã học viên")
            {
                return db.HocViens.Where(p => p.MaHV.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã phụ huynh")
            {
                return db.HocViens.Where(p => p.MaPH.Contains(tuKhoa)).ToList();
            }
            return new List<HocVien>();
        }
        public bool ThemHocVien(HocVien hv)
        {
            try
            {
                db.HocViens.Add(hv);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatHocVien(HocVien hv)
        {
            try
            {
                var H = db.HocViens.FirstOrDefault(h => h.MaHV == hv.MaHV);
                if (H == null) return false;

                H.MaPH = hv.MaPH;
                H.HoTen = hv.HoTen;
                H.GioiTinh = hv.GioiTinh;
                H.NgaySinh = hv.NgaySinh;
                H.HocLuc = hv.HocLuc;

                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
    }
}
