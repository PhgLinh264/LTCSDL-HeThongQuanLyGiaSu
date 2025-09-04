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
    public class DangKyKH_BL
    {
        private DangKyKH_DL dangKyKHDL;
        private KhoaHocDL khoaHocDL = new KhoaHocDL();
        private ThamGiaKH_DL thamGiaKHDL = new ThamGiaKH_DL();
        private HocVienDL hocVienDL = new HocVienDL();
        private DanhGiaKH_DL danhGiaKHDL = new DanhGiaKH_DL();
        private PhuHuynhDL phuHuynhDL = new PhuHuynhDL();
        private HopDongPH_DL hopDongPHDL = new HopDongPH_DL();
        //public string error;

        public DangKyKH_BL()
        {
            dangKyKHDL = new DangKyKH_DL();
        }
        public List<DangKyKH> GetDangKyKH()
        {
            try
            {
                return dangKyKHDL.GetDangKyKH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<DangKyKH> GetDanhSachDangKy(string maKH)
        {
            // Trả về danh sách đăng ký khóa học của phụ huynh
            return dangKyKHDL.GetDanhSachDangKy(maKH);
        }
        public List<DangKyKH> TimKiemDangKyKH(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return dangKyKHDL.TimKiemDangKyKH(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaPH()
        {
            try
            {
                return dangKyKHDL.GetDanhSachMaPH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaKH()
        {
            try
            {
                return dangKyKHDL.GetDanhSachMaKH();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public List<string> GetDanhSachMaPHtheoMaKH(string maKH)
        {
            try
            {
                return dangKyKHDL.GetDanhSachMaPHtheoMaKH(maKH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public string GetMaPHtheoMaKH(string maKH)
        {
            try
            {
                return dangKyKHDL.GetMaPHtheoMaKH(maKH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDangKyKH(DangKyKH dk, out string error)
        {
            error = "";
            var dsHopDong = phuHuynhDL.GetPhuHuynh();
            var coHopDong = dsHopDong.Any(hd => hd.MaPH == dk.MaPH);
            if (!coHopDong)
            {
                error = "Phụ huynh chưa ký hợp đồng";
                return false;
            }

            if (string.IsNullOrEmpty(dk.MaPH) ||
                string.IsNullOrEmpty(dk.MaKH) ||
                dk.NgayDangKy.Date == DateTime.Now ||
                string.IsNullOrEmpty(dk.SoLuongHV.ToString()))
            {
                error = "Thiếu thông tin";
                return false;
            }

            //Kiểm tra nếu MaPH, MaKH, NgayDK đã tồn tại trong bảng tham gia
           var dangKyCu = dangKyKHDL.GetDangKyKH()
               .FirstOrDefault(dkCu => dkCu.MaPH == dk.MaPH && dkCu.MaKH == dk.MaKH && dkCu.NgayDangKy == dk.NgayDangKy);
            if (dangKyCu != null)
            {
                error = "Thông tin đăng ký đã tồn tại";
                return false;
            }

            // Kiểm tra số lượng học viên thực tế của phụ huynh
            int soLuongHVThucTe = dangKyKHDL.DemSoLuongHocVienTheoMaPH(dk.MaPH);
            if (dk.SoLuongHV > soLuongHVThucTe)
            {
                error = "Số lượng học viên vượt quá thực tế";
                return false;
            }

            return dangKyKHDL.ThemDangKyKH(dk);
        }
        public bool CapNhatDangKyKH(DangKyKH dk, out string error)
        {
            error = "";
            var dsHopDong = hopDongPHDL.GetHopDongPH();
            var dsPH = phuHuynhDL.GetPhuHuynh();

            var coHopDong = dsHopDong.Any(hd => hd.MaPH == dk.MaPH);
            if (!coHopDong)
            {
                error = "Phụ huynh chưa ký hợp đồng";
                return false;
            }

            if (string.IsNullOrEmpty(dk.MaPH) ||
                string.IsNullOrEmpty(dk.MaKH) ||
                dk.NgayDangKy.Date == DateTime.Now ||
                string.IsNullOrEmpty(dk.SoLuongHV.ToString()))
            {
                error = "Thiếu thông tin";
                return false;
            }

            int soLuongHVThucTe = dangKyKHDL.DemSoLuongHocVienTheoMaPH(dk.MaPH);
            if (dk.SoLuongHV > soLuongHVThucTe)
            {
                error = "Số lượng học viên sai thực tế";
                return false;
            }

            var dsThamGia = thamGiaKHDL.GetThamGiaKH();
            var dsDangKy = dangKyKHDL.GetDangKyKH();
            // 1. Tổng số học viên đã tham gia KH này (từ ThamGiaKH)
            int soLuongThamGia = dsThamGia.Count(h => h.MaKH == dk.MaKH);
            // 2. Tổng số học viên đăng ký KH này, ngoại trừ dòng hiện tại
            int tongDangKyTruHienTai = dsDangKy
                .Where(d => d.MaKH == dk.MaKH && !(d.MaPH == dk.MaPH && d.MaKH == dk.MaKH)).Sum(d => d.SoLuongHV);
            // 3. Tổng số đăng ký mới sau khi cập nhật
            int tongDangKySauCapNhat = tongDangKyTruHienTai + dk.SoLuongHV;
            // 4. Kiểm tra logic: nếu số học viên đã tham gia > số đăng ký mới → lỗi
            if (soLuongThamGia > tongDangKySauCapNhat)
            {
                error = $"Để cập nhật số lượng, hãy hủy ở mục Học Viên";
                return false;
            }

            return dangKyKHDL.CapNhatDangKyKH(dk);
        }
        public bool XoaDangKyKH(string maPH, string maKH, DateTime ngayDangKy)
        {
            // Kiểm tra nếu tồn tại học viên nào của phụ huynh trong bảng HocVien
            var dsHocVien = hocVienDL.GetHocVienTheoMaPH(maPH); 
            if (dsHocVien.Any())
            {
                // Kiểm tra nếu có bất kỳ học viên nào đang tham gia khóa học đó
                foreach (var hv in dsHocVien)
                {
                    bool daThamGia = thamGiaKHDL.CoThamGiaKhoaHoc(hv.MaHV, maKH);
                    if (daThamGia)
                        return false; // Có học viên tham gia => không xóa được
                }
            }
            //Kiểm tra nếu đã đánh giá khóa học rồi => không xóa
            var danhGiaList = danhGiaKHDL.GetDanhGiaKH();
            bool daDanhGia = danhGiaList.Any(dg => dg.MaPH == maPH && dg.MaKH == maKH);
            if (daDanhGia)
                return false;

            // Nếu không có ràng buộc thì tiến hành xóa
            return dangKyKHDL.XoaDangKyKH(maPH, maKH, ngayDangKy);
        }
    }
}
