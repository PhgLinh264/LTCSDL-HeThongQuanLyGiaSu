using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DangKyKH_DL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public DangKyKH_DL()
        {

        }
        public List<DangKyKH> GetDangKyKH()
        {
            try
            {
                return db.DangKyKHs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<DangKyKH> GetDanhSachDangKy(string maKH)
        {
            // Trả về danh sách đăng ký khóa học của phụ huynh
            return db.DangKyKHs.Where(dk => dk.MaKH == maKH).ToList();
        }
        public List<DangKyKH> TimKiemDangKyKH(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã phụ huynh")
            {
                return db.DangKyKHs.Where(p => p.MaPH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã khóa học")
            {
                return db.DangKyKHs.Where(p => p.MaKH.Contains(tuKhoa)).ToList();
            }
            return new List<DangKyKH>();
        }
        public List<string> GetDanhSachMaKH()
        {
            try
            {
                return db.KhoaHocs.Where(p => p.TrangThai == "Hoạt động").Select(p => p.MaKH).Distinct().ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaPH()
        {
            try
            {
                return db.PhuHuynhs.Where(p => p.TrangThai == "Hoạt động").Select(p => p.MaPH).Distinct().ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaPHtheoMaKH(string maKH)
        {
            return db.DangKyKHs
                     .Where(dk => dk.MaKH == maKH)
                     .Select(dk => dk.MaPH)
                     .Distinct()
                     .ToList();
        }
        public string GetMaPHtheoMaKH(string maKH)
        {
            if (string.IsNullOrEmpty(maKH))
                return null;

            var maPH = db.DangKyKHs
                         .Where(dk => dk.MaKH == maKH)
                         .Select(dk => dk.MaPH)
                         .FirstOrDefault(); // Lấy MaPH đầu tiên nếu có

            return maPH;
        }
        public int DemSoLuongHocVienTheoMaPH(string maPH)
        {
            try
            {
                return db.HocViens.Count(hv => hv.MaPH == maPH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDangKyKH(DangKyKH kh)
        {
            try
            {
                db.DangKyKHs.Add(kh);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public bool CapNhatDangKyKH(DangKyKH khMoi)
        {
            try
            {
                var kh = db.DangKyKHs.FirstOrDefault(p => p.MaPH == khMoi.MaPH && p.MaKH == khMoi.MaKH && p.NgayDangKy == khMoi.NgayDangKy);
                if (kh == null)
                {
                    return false;
                }
                kh.NgayDangKy = khMoi.NgayDangKy;
                kh.SoLuongHV = khMoi.SoLuongHV;
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool XoaDangKyKH(string maPH, string maKH, DateTime ngayDangKy)
        {
            try
            {
                var kh = db.DangKyKHs.FirstOrDefault(p => p.MaPH == maPH && p.MaKH == maKH && p.NgayDangKy == ngayDangKy);
                if (kh == null)
                {
                    return false;
                }
                db.DangKyKHs.Remove(kh);
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
