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
    public class PhuHuynhBL
    {
        PhuHuynhDL phuHuynhDL;
        public PhuHuynhBL()
        {
            phuHuynhDL = new PhuHuynhDL();
        }
        public List<PhuHuynh> GetPhuHuynh()
        {
            try
            {
                return phuHuynhDL.GetPhuHuynh().ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<PhuHuynh> TimKiemTheoMaPH(string maPH)
        {
            if (maPH == null)
                return new List<PhuHuynh>();
            try
            {
                return phuHuynhDL.TimKiemTheoMaPH(maPH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaPH()
        {
            return phuHuynhDL.GetDanhSachMaPH();
        }
        public bool ThemPhuHuynh(PhuHuynh ph)
        {
            if (string.IsNullOrWhiteSpace(ph.HoTen) ||
                string.IsNullOrWhiteSpace(ph.SDT) ||
                string.IsNullOrWhiteSpace(ph.DiaChi) ||
                string.IsNullOrWhiteSpace(ph.Email))
            {
                return false;
            }
            else
            {
                return phuHuynhDL.ThemPhuHuynh(ph);
            }
        }
        public bool CapNhatPhuHuynh(PhuHuynh ph)
        {
            if (string.IsNullOrWhiteSpace(ph.HoTen) ||
                string.IsNullOrWhiteSpace(ph.SDT) ||
                string.IsNullOrWhiteSpace(ph.DiaChi) ||
                string.IsNullOrWhiteSpace(ph.Email))
            {
                return false;
            }
            else
            {
                return phuHuynhDL.CapNhatPhuHuynh(ph);
            }
        }
    }
}
