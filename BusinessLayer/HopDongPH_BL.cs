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
    public class HopDongPH_BL
    {
        HopDongPH_DL hopDongPH_DL;
        public HopDongPH_BL()
        {
            hopDongPH_DL = new HopDongPH_DL();
        }
        public List<HopDongPH> GetHopDongPH()
        {
            try
            {
                return hopDongPH_DL.GetHopDongPH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HopDongPH> TimKiemHopDongPH(string maPH)
        {
            if (!string.IsNullOrEmpty(maPH))
            {
                return hopDongPH_DL.TimKiemHopDongPH(maPH);
            }
            else
                return null;
        }
        public List<string> GetMaPH()
        {
            try
            {
                return hopDongPH_DL.GetMaPH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatHopDongPH(HopDongPH hd)
        {
            try
            {
                return hopDongPH_DL.CapNhatHopDongPH(hd);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
