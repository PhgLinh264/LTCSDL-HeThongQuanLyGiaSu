using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HopDongGS_DL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public HopDongGS_DL()
        {

        }
        public List<HopDongGS> GetHopDongGS()
        {
            try
            {
                return db.HopDongGSs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<HopDongGS> TimKiemHopDongGS(string maGS)
        {
            try
            {
                return db.HopDongGSs.Where(p => p.MaGS.Contains(maGS)).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetMaGS()
        {
            try
            {
                return db.GiaSus.Select(p => p.MaGS).ToList();
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
                var pH = db.HopDongGSs.FirstOrDefault(p => p.MaGS == gs.MaGS);
                var giaSu = db.GiaSus.FirstOrDefault(ph => ph.MaGS == gs.MaGS);
                if (pH != null) // nếu có PH
                {
                    pH.NgayKy = gs.NgayKy;
                    pH.NgayHuy = gs.NgayHuy;
                    pH.LyDo = gs.LyDo;
                    // Nếu hợp đồng bị hủy thì cập nhật TrangThai của PhuHuynh
                    if (gs.NgayHuy.HasValue)
                    {
                        if (giaSu != null)
                        {
                            giaSu.TrangThai = "Hủy HD";
                        }
                    }
                    else
                    {
                        giaSu.TrangThai = "Hoạt động";
                    }
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    // Thêm 
                    db.HopDongGSs.Add(gs);
                    // Nếu có ngày hủy thì cũng cập nhật trạng thái PH
                    if (gs.NgayHuy.HasValue)
                    {
                        if (giaSu != null)
                        {
                            giaSu.TrangThai = "Hủy HD";
                        }
                    }
                    else
                    {
                        giaSu.TrangThai = "Hoạt động";
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
