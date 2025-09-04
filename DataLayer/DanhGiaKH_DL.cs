using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DanhGiaKH_DL
    {
        QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public DanhGiaKH_DL()
        {

        }
        public List<DanhGiaKH> GetDanhGiaKH()
        {
            try
            {
                return db.DanhGiaKHs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<DanhGiaKH> TimKiemDanhGiaKH(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã phụ huynh")
            {
                return db.DanhGiaKHs.Where(p => p.MaPH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã học viên")
            {
                return db.DanhGiaKHs.Where(p => p.MaHV.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã khóa học")
            {
                return db.DanhGiaKHs.Where(p => p.MaKH.Contains(tuKhoa)).ToList();
            }
            return new List<DanhGiaKH>();
        }
        public List<string> GetDanhSachMaPH()
        {
            try
            {
                return db.PhuHuynhs.Select(p => p.MaPH).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaHVTheoMaPH(string maPH)
        {
            try
            {
                return db.HocViens.Where(hv => hv.MaPH == maPH).Select(hv => hv.MaHV).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetMaKHTheoMaHV(string maHV)
        {
            try
            {
                return db.ThamGiaKHs
                         .Where(dg => dg.MaHV == maHV)
                         .Select(dg => dg.MaKH)
                         .ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDanhGiaKH(DanhGiaKH dg)
        {
            try
            {
                //kiểm tra học viên đã đăng ký lớp học hay chưa
                var hoc = db.DanhGiaKHs.FirstOrDefault(h => h.MaHV == dg.MaHV && h.MaKH == dg.MaKH);
                if (hoc != null)
                {
                    return false;
                }
                db.DanhGiaKHs.Add(dg);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool XoaDanhGiaKH(string maPH, string maHV, string maKH)
        {
            try
            {
                var hoc = db.DanhGiaKHs.FirstOrDefault(h => h.MaKH == maKH && h.MaPH == maPH && h.MaHV == maHV);
                if (hoc == null)
                {
                    return false;
                }
                db.DanhGiaKHs.Remove(hoc);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
