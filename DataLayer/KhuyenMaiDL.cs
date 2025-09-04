using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class KhuyenMaiDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public KhuyenMaiDL()
        {

        }
        public List<KhuyenMai> GetKhuyenMai()
        {
            try
            {
                return db.KhuyenMais.ToList();
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
        public List<string> GetDanhSachMaKM()
        {
            try
            {
                return db.KhuyenMais.Select(km => km.MaKM).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<KhuyenMai> TimKiemKM(string maKM)
        {
            try
            {
                return db.KhuyenMais.Where(ph => ph.MaKM == maKM).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemKhuyenMai(KhuyenMai km)
        {
            try
            {
                db.KhuyenMais.Add(km);
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
