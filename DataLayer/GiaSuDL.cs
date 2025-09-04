using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public  class GiaSuDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public GiaSuDL()
        {
            
        }
        public List<GiaSu> GetGiaSu()
        {
            try
            {
                return db.GiaSus.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public List<GiaSu> TimKiemGiaSu(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã gia sư")
            {
                return db.GiaSus.Where(p => p.MaGS.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Giới tính")
            {
                return db.GiaSus.Where(p => p.GioiTinh.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Xếp hạng")
            {
                return db.GiaSus.Where(p => p.XepHang.Contains(tuKhoa)).ToList();
            }
            return new List<GiaSu>(); 
        }
        public bool ThemGiaSu(GiaSu gs)
        {
            try
            {
                gs.TrangThai = "Hoạt động";
                db.GiaSus.Add(gs);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatGiaSu(GiaSu gs)
        {
            try
            {
                var G = db.GiaSus.FirstOrDefault(g => g.MaGS == gs.MaGS);
                if (G == null) return false;

                G.HoTen = gs.HoTen;
                G.SDT = gs.SDT;
                G.DiaChi = gs.DiaChi;
                G.GioiTinh = gs.GioiTinh;
                G.NgaySinh = gs.NgaySinh;
                G.DaiHoc = gs.DaiHoc;
                G.MonDay = gs.MonDay;
                G.XepHang = gs.XepHang;

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
