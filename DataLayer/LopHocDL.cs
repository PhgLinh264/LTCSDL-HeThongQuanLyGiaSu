using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LopHocDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public LopHocDL()
        {

        }
        public List<LopHoc> GetLopHoc()
        {
            try
            {
                return db.LopHocs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<string> GetDanhSachMaGS()
        {
            try
            {
                return db.GiaSus.Where(p => p.TrangThai == "Hoạt động").Select(p => p.MaGS).Distinct().ToList();
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
        public List<string> GetDanhSachMaLH()
        {
            try
            {
                return db.LopHocs.Where(p => p.TrangThai == "Hoạt động").Select(p => p.MaLH).Distinct().ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<LopHoc> TimKiemLopHoc(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã lớp học")
            {
                return db.LopHocs.Where(p => p.MaLH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã gia sư")
            {
                return db.LopHocs.Where(p => p.MaGS.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã phụ huynh")
            {
                return db.LopHocs.Where(p => p.MaPH.Contains(tuKhoa)).ToList();
            }
            return new List<LopHoc>();

        }
        public bool CoThamGiaLopHoc(string maHV, string maLH)
        {
            try
            {
                return db.Hocs.Any(tg => tg.MaHV == maHV && tg.MaLH == maLH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemLopHoc(LopHoc lh)
        {
            try
            {
                lh.TrangThai = "Hoạt động";
                db.LopHocs.Add(lh);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatLopHoc(LopHoc lh)
        {
            try
            {
                var LH = db.LopHocs.FirstOrDefault(l => l.MaLH == lh.MaLH);
                if (LH == null) return false;


                LH.MaGS = lh.MaGS;
                LH.MaPH = lh.MaPH;
                LH.MonHoc = lh.MonHoc;
                LH.SoBuoi = lh.SoBuoi;
                LH.HocPhi = lh.HocPhi;
                LH.TrangThai = lh.TrangThai;
                LH.NgayNhanLop = lh.NgayNhanLop;
                LH.SoLuongHV = lh.SoLuongHV;
                LH.NgayDangKy = lh.NgayDangKy;
                LH.YeuCau = lh.YeuCau;

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
