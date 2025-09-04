using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class HocDL
    {
        private QuanLyGiaSuContext db = new QuanLyGiaSuContext();
        public HocDL()
        {

        }
        public List<Hoc> GetHoc()
        {
            try
            {
                return db.Hocs.ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<Hoc> TimKiemHoc(string tieuChi, string tuKhoa)
        {
            if (tieuChi == "Mã lớp học")
            {
                return db.Hocs.Where(p => p.MaLH.Contains(tuKhoa)).ToList();
            }
            else if (tieuChi == "Mã học viên")
            {
                return db.Hocs.Where(p => p.MaHV.Contains(tuKhoa)).ToList();
            }
            return new List<Hoc>();
        }
        public List<HocVien> GetDanhSachHocVienTheoMaPH(string maPH)
        {
            try
            {
                // Lấy danh sách học viên có MaPH tương ứng
                return db.HocViens.Where(hv => hv.MaPH == maPH).ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CapNhatHoc(Hoc h)
        {
            try
            {
                var hocCu = db.Hocs.FirstOrDefault(p => p.MaLH == h.MaLH && p.MaHV == h.MaHV);
                if (hocCu != null) // nếu có hocCu
                {
                    //Nếu MaHV giống nhau thì không cần thay đổi
                    if (hocCu.MaHV == h.MaHV)
                        return false;

                    // Xóa học viên cũ khỏi lớp
                    //db.Hocs.Remove(hocCu);
                    //db.SaveChanges(); // Phải save để tránh trùng khóa khi thêm mới
                }

                // Thêm học viên mới vào lớp
                db.Hocs.Add(h);
                db.SaveChanges();

                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool XoaDangKyHoc(string maLH, string maHV)
        {
            try
            {
                var hoc = db.Hocs.FirstOrDefault(p => p.MaLH == maLH && p.MaHV == maHV);
                if (hoc == null)
                {
                    return false;
                }
                db.Hocs.Remove(hoc);
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
