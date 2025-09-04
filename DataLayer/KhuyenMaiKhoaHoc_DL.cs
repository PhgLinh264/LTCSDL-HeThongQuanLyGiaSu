using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KhuyenMaiKhoaHoc_DL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public KhuyenMaiKhoaHoc_DL()
        {

        }
        public List<KhoaHoc> GetKhoaHoc()
        {
            try
            {
                return db.KhoaHocs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public KhoaHoc GetKhoaHocByMaKH(string maKH)
        {
            try
            {
                return db.KhoaHocs.FirstOrDefault(lh => lh.MaKH == maKH);
            }
            catch (SqlException ex)
            {

                throw ex;
            }

        }
        public List<string> GetDanhSachMaKH()
        {
            try
            {
                return db.KhoaHocs.Select(p => p.MaKH).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<KhoaHoc> TimKiem(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã khóa học")
            {
                return db.KhoaHocs.Where(p => p.MaKH.Contains(tuKhoa)).ToList();
            }
            return new List<KhoaHoc>();

        }
        public bool CapNhatKhuyenMai(KhoaHoc kh)
        {
            try
            {
                var KH = db.KhoaHocs.FirstOrDefault(l => l.MaKH == kh.MaKH);
                if (KH == null) return false;

                KH.MaKM = kh.MaKM;
                KH.TienKM = kh.TienKM;

                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool XoaKhuyenMaiKhoiKhoaHoc(string maKH)
        {
            try
            {
                var Kh = db.KhoaHocs.FirstOrDefault(l => l.MaKH == maKH);
                if (Kh == null) return false;

                Kh.MaKM = null;
                Kh.TienKM = 0;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
