using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PhuHuynhDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public PhuHuynhDL()
        {
            
        }
        public List<PhuHuynh> GetPhuHuynh()
        {
            try
            {
                return db.PhuHuynhs.ToList();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public List<PhuHuynh> TimKiemTheoMaPH(string maPH)
        {
            try
            {
                return db.PhuHuynhs.Where(ph => ph.MaPH == maPH).ToList();
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
                return db.PhuHuynhs.Select(p => p.MaPH).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách Mã Phụ Huynh.", ex);
            }
        }
        public bool ThemPhuHuynh(PhuHuynh ph)
        {
            try
            {
                ph.TrangThai = "Hoạt động";
                db.PhuHuynhs.Add(ph);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatPhuHuynh(PhuHuynh phMoi)
        {
            try
            {
                var phUpdate = db.PhuHuynhs.FirstOrDefault(p => p.MaPH == phMoi.MaPH);
                if (phUpdate == null) return false;

                phUpdate.HoTen = phMoi.HoTen;
                phUpdate.SDT = phMoi.SDT;
                phUpdate.DiaChi = phMoi.DiaChi;
                phUpdate.Email = phMoi.Email;

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
