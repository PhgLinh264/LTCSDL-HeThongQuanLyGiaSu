using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DoiTacBL
    {
        private DoiTacDL doiTacDL;

        public DoiTacBL()
        {
            doiTacDL = new DoiTacDL();
        }
        public List<DoiTac> GetDoiTac()
        {
            try
            {
                return doiTacDL.GetDoiTac();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<DoiTac> TimKiemDoiTac(string tuKhoa)
        {
            if (tuKhoa == null)
                return null;
            try
            {
                return doiTacDL.TimKiemDoiTac(tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDoiTac(DoiTac dt)
        {
            if (string.IsNullOrWhiteSpace(dt.TenDT) ||
                string.IsNullOrWhiteSpace(dt.Email) ||
                string.IsNullOrWhiteSpace(dt.TrangThai))
            {
                return false;
            }
            else
            {
                return doiTacDL.ThemDoiTac(dt);
            }
        }
        public bool CapNhatDoiTac(DoiTac dt)
        {
            if (string.IsNullOrWhiteSpace(dt.TenDT) ||
                string.IsNullOrWhiteSpace(dt.Email) ||
                string.IsNullOrWhiteSpace(dt.TrangThai))
            {
                return false;
            }
            else
            {
                return doiTacDL.CapNhatDoiTac(dt);
            }
        }
    }
}
