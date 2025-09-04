using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DanhGiaLH_DL
    {
        QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public DanhGiaLH_DL()
        {

        }
        public List<DanhGiaLH> GetDanhGiaLH()
        {
            try
            {
                return db.DanhGiaLHs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<DanhGiaLH> TimKiemDanhGiaLH(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã phụ huynh")
            {
                return db.DanhGiaLHs.Where(p => p.MaPH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã học viên")
            {
                return db.DanhGiaLHs.Where(p => p.MaHV.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã lớp học")
            {
                return db.DanhGiaLHs.Where(p => p.MaLH.Contains(tuKhoa)).ToList();
            }
            return new List<DanhGiaLH>();
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
        public List<string> GetDanhSachMaHVTheoMaPH(string maPH)
        {
            try
            {
                return db.HocViens
                         .Where(dg => dg.MaPH == maPH)
                         .Select(dg => dg.MaHV)
                         .Distinct()
                         .ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetMaLHTheoMaHV(string maHV)
        {
            try
            {
                return db.Hocs
                         .Where(dg => dg.MaHV == maHV)
                         .Select(dg => dg.MaLH)
                         .ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDanhGiaLH(DanhGiaLH dg)
        {
            try
            {
                //kiểm tra học viên đã đăng ký lớp học hay chưa
                var hoc = db.DanhGiaLHs.FirstOrDefault(h => h.MaHV == dg.MaHV && h.MaLH == dg.MaLH);
                if (hoc != null)
                {
                    return false;
                }
                db.DanhGiaLHs.Add(dg);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool XoaDanhGiaLH(string maPH, string maHV, string maLH)
        {
            try
            {
                var hoc = db.DanhGiaLHs.FirstOrDefault(h => h.MaLH == maLH && h.MaPH == maPH && h.MaHV == maHV);
                if (hoc == null)
                {
                    return false;
                }
                db.DanhGiaLHs.Remove(hoc);
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
