using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KhoaHocDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public KhoaHocDL()
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
        public List<string> GetDanhSachMaDT()
        {
            try
            {
                return db.DoiTacs.Select(p => p.MaDT).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<KhoaHoc> TimKiemKhoaHoc(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã khóa học")
            {
                return db.KhoaHocs.Where(p => p.MaKH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã đối tác")
            {
                return db.KhoaHocs.Where(p => p.MaDT.Contains(tuKhoa)).ToList();
            }
            return new List<KhoaHoc>();
        }
        public bool ThemKhoaHoc(KhoaHoc kh)
        {
            try
            {
                db.KhoaHocs.Add(kh);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatKhoaHoc(KhoaHoc kh)
        {
            try
            {
                var K = db.KhoaHocs.FirstOrDefault(p => p.MaKH == kh.MaKH);
                if (K == null) return false;

                K.TenKH = kh.TenKH;
                K.LinhVuc = kh.LinhVuc;
                K.ThoiGian = kh.ThoiGian;
                K.HocPhi = kh.HocPhi;
                K.TrangThai = kh.TrangThai;
                K.MaDT = kh.MaDT;
                

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
