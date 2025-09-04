using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KhuyenMaiLopHoc_DL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public KhuyenMaiLopHoc_DL()
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
        public string GetPhanTram(string maKM)
        {
            try
            {
                var km = db.KhuyenMais.FirstOrDefault(k => k.MaKM == maKM);
                if (km != null)
                {
                    return km.PhanTram.ToString(); // Trả về giá trị PhanTram
                }
                return null;
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            
        }
        public LopHoc GetLopHocByMaLH(string maLH)
        {
            try
            {
                return db.LopHocs.FirstOrDefault(lh => lh.MaLH == maLH);
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
                return db.LopHocs.Select(p => p.MaLH).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<LopHoc> TimKiem(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã lớp học")
            {
                return db.LopHocs.Where(p => p.MaLH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã phụ huynh")
            {
                return db.LopHocs.Where(p => p.MaPH.Contains(tuKhoa)).ToList();
            }
            return new List<LopHoc>();

        }
        public bool CapNhatKhuyenMai(LopHoc lh)
        {
            try
            {
                var LH = db.LopHocs.FirstOrDefault(l => l.MaLH == lh.MaLH);
                if (LH == null) return false;

                LH.MaKM = lh.MaKM;
                LH.TienKM = lh.TienKM;

                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool XoaKhuyenMaiKhoiLopHoc(string maLH)
        {
            try
            {
                var lh = db.LopHocs.FirstOrDefault(l => l.MaLH == maLH);
                if (lh == null) return false;

                lh.MaKM = null;
                lh.TienKM = 0;

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
