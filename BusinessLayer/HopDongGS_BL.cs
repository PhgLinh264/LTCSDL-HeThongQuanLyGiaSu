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
    public class HopDongGS_BL
    {
        HopDongGS_DL hopDongGS_DL;
        public HopDongGS_BL()
        {
            hopDongGS_DL = new HopDongGS_DL();
        }
        public List<HopDongGS> GetHopDongGS()
        {
            try
            {
                return hopDongGS_DL.GetHopDongGS();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HopDongGS> TimKiemHopDongGS(string maGS)
        {
            if (!string.IsNullOrEmpty(maGS))
            {
                return hopDongGS_DL.TimKiemHopDongGS(maGS);
            }
            else
                return null;
        }
        public List<string> GetMaGS()
        {
            try
            {
                return hopDongGS_DL.GetMaGS();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatHopDongGS(HopDongGS gs)
        {
            try
            {
                return hopDongGS_DL.CapNhatHopDongGS(gs);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
