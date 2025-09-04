using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DoiTacDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public DoiTacDL()
        {

        }
        public List<DoiTac> GetDoiTac()
        {
            try
            {
                return db.DoiTacs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<DoiTac> TimKiemDoiTac(string tuKhoa)
        {
            try
            {
                return db.DoiTacs.Where(p => p.MaDT.Contains(tuKhoa)).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDoiTac(DoiTac dt)
        {
            try
            {
                db.DoiTacs.Add(dt);
                db.SaveChanges();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatDoiTac(DoiTac dt)
        {
            try
            {
                var D = db.DoiTacs.FirstOrDefault(p => p.MaDT == dt.MaDT);
                if (D == null) return false;

                D.TenDT = dt.TenDT;
                D.Email = dt.Email;
                D.TrangThai = dt.TrangThai;

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
