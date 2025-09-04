using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ThamGiaKH_DL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public ThamGiaKH_DL()
        {

        }
        public List<ThamGiaKH> GetThamGiaKH()
        {
            try
            {
                return db.ThamGiaKHs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<ThamGiaKH> GetDanhSachThamGia(string maKH)
        {
            // Trả về danh sách tham gia khóa học của học viên
            return db.ThamGiaKHs.Where(tg => tg.MaKH == maKH).ToList();
        }
        public List<ThamGiaKH> TimKiemThamGiaKH(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã khóa học")
            {
                return db.ThamGiaKHs.Where(p => p.MaKH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã học viên")
            {
                return db.ThamGiaKHs.Where(p => p.MaHV.Contains(tuKhoa)).ToList();
            }
            return new List<ThamGiaKH>();
        }
        public List<HocVien> GetHocVienTheoMaPH(string maPH)
        {
            try
            {
                return db.HocViens.Where(hv => hv.MaPH == maPH).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CoThamGiaKhoaHoc(string maHV, string maKH)
        {
            try
            {
                return db.ThamGiaKHs.Any(tg => tg.MaHV == maHV && tg.MaKH == maKH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            
        }
        public bool CapNhatThamGiaKH(ThamGiaKH tg)
        {
            try
            {
                var thamGiaCu = db.ThamGiaKHs.FirstOrDefault(p => p.MaKH == tg.MaKH && p.MaHV == tg.MaHV);
                if (thamGiaCu != null) // nếu có hocCu
                {
                    return false;
                }
                // Thêm học viên mới vào lớp
                db.ThamGiaKHs.Add(tg);
                db.SaveChanges();

                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool XoaThamGiaKH(string maHV, string maKH)
        {
            var entity = db.ThamGiaKHs
                .FirstOrDefault(tg => tg.MaHV == maHV && tg.MaKH == maKH);

            if (entity != null)
            {
                db.ThamGiaKHs.Remove(entity);
                db.SaveChanges();
                return true;
            }
            return false;

        }
    }
}
