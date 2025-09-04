using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HopDongPH_DL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public HopDongPH_DL()
        {

        }
        public List<HopDongPH> GetHopDongPH()
        {
            try
            {
                return db.HopDongPHs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<HopDongPH> TimKiemHopDongPH(string maPH)
        {
            try
            {
                return db.HopDongPHs.Where(p => p.MaPH.Contains(maPH)).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetMaPH()
        {
            try
            {
                return db.PhuHuynhs.Select(p => p.MaPH).ToList();
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
                var pH = db.HopDongPHs.FirstOrDefault(p => p.MaPH == hd.MaPH);
                var phuHuynh = db.PhuHuynhs.FirstOrDefault(ph => ph.MaPH == hd.MaPH);
                if (pH != null) // nếu có PH
                {
                    pH.NgayKy = hd.NgayKy;
                    pH.NgayHuy = hd.NgayHuy;
                    pH.LyDo = hd.LyDo;
                    // Nếu hợp đồng bị hủy thì cập nhật TrangThai của PhuHuynh
                    if (hd.NgayHuy.HasValue)
                    {
                        if (phuHuynh != null)
                        {
                            phuHuynh.TrangThai = "Hủy HD";
                            
                        }
                    }
                    else
                    {
                        phuHuynh.TrangThai = "Hoạt động";
                    }    
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    // Thêm 
                    db.HopDongPHs.Add(hd);
                    // Nếu có ngày hủy thì cũng cập nhật trạng thái PH
                    if (hd.NgayHuy.HasValue)
                    {
                        if (phuHuynh != null)
                        {
                            phuHuynh.TrangThai = "Hủy HD";
                        }
                    }
                    else
                    {
                        phuHuynh.TrangThai = "Hoạt động";
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
