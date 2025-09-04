using DataLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class ThamGiaKH_BL
    {
        private ThamGiaKH_DL thamGiaKH_DL;
        private KhoaHocDL khoaHocDL = new KhoaHocDL();
        private DanhGiaKH_DL danhGiaKHDL = new DanhGiaKH_DL();
        HocVienDL hocVienDL = new HocVienDL();
        DangKyKH_DL dangKyKH_DL = new DangKyKH_DL();
        public ThamGiaKH_BL()
        {
            thamGiaKH_DL = new ThamGiaKH_DL();
        }
        public List<ThamGiaKH> GetThamGiaKH()
        {
            try
            {
                return thamGiaKH_DL.GetThamGiaKH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<ThamGiaKH> GetDanhSachThamGia(string maKH)
        {
            // Trả về danh sách tham gia khóa học của học viên
            return thamGiaKH_DL.GetDanhSachThamGia(maKH);
        }
        public List<ThamGiaKH> TimKiemThamGiaKH(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return thamGiaKH_DL.TimKiemThamGiaKH(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HocVien> GetHocVienTheoMaPH(string maPH)
        {
            if (string.IsNullOrWhiteSpace(maPH))
                return new List<HocVien>();

            return thamGiaKH_DL.GetHocVienTheoMaPH(maPH);
        }
        public bool CoThamGiaKhoaHoc(string maHV, string maKH)
        {
            try
            {
                return thamGiaKH_DL.CoThamGiaKhoaHoc(maHV, maKH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public bool CapNhatThamGiaKH(ThamGiaKH tg, out string error)
        {
            error = "";
            if(string.IsNullOrEmpty(tg.MaKH) || string.IsNullOrEmpty(tg.MaHV))
            {
                error = "Thiếu thông tin!";
                return false;
            }    
            // Kiểm tra nếu MaHV và MaKH đã tồn tại trong bảng tham gia
            var thamGiaTrung = thamGiaKH_DL.GetThamGiaKH()
                .FirstOrDefault(tgCu => tgCu.MaHV == tg.MaHV && tgCu.MaKH == tg.MaKH);
            if (thamGiaTrung != null)
            {
                error = "Trùng thông tin!";
                return false;  // Nếu đã tồn tại thì trả về false
            }

            // Lấy MaPH từ MaHV
            var hocVien = hocVienDL.GetHocVien().FirstOrDefault(hv => hv.MaHV == tg.MaHV);
            string maPH = hocVien.MaPH;
            // Lấy thông tin đăng ký khóa học từ bảng DangKyKH
            var dangKy = dangKyKH_DL.GetDangKyKH().FirstOrDefault(dk => dk.MaPH == maPH && dk.MaKH == tg.MaKH);
            int soLuongDangKy = dangKy.SoLuongHV;
            // Đếm số học viên của phụ huynh đó đã tham gia khóa học này
            int soLuongThamGia = (
                from tgkh in thamGiaKH_DL.GetThamGiaKH()
                join hv in hocVienDL.GetHocVien() on tgkh.MaHV equals hv.MaHV
                where tgkh.MaKH == tg.MaKH && hv.MaPH == maPH
                select hv.MaHV).Distinct().Count();

            // Nếu số lượng đã tham gia >= số lượng đăng ký thì không cho thêm nữa
            if (soLuongThamGia >= soLuongDangKy)
            {
                error = "Chỉ thêm học viên theo số lượng Phụ huynh đã đăng ký!";
                return false;
            }

            return thamGiaKH_DL.CapNhatThamGiaKH(tg);
        }
        public bool XoaThamGiaKH(string maHV, string maKH)
        {
            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(maHV))
            {
                return false;
            }
            //Kiểm tra nếu đã đánh giá khóa học rồi => không xóa
            var danhGiaList = danhGiaKHDL.GetDanhGiaKH();
            bool daDanhGia = danhGiaList.Any(dg => dg.MaKH == maKH && dg.MaHV == maHV);
            if (daDanhGia)
                return false;

            return thamGiaKH_DL.XoaThamGiaKH(maHV, maKH);
        }
    }
}
