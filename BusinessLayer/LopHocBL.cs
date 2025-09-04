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
    public class LopHocBL
    {
        LopHocDL lopHocDL;
        HocDL hocDL = new HocDL();
        HopDongPH_DL hopDongPHDL = new HopDongPH_DL();
        HopDongGS_DL hopDongGSDL = new HopDongGS_DL();
        HocVienDL hocVienDL = new HocVienDL();
        //GiaSuDL giaSuDL = new GiaSuDL();
        public LopHocBL()
        {
            lopHocDL = new LopHocDL();
        }
        public List<LopHoc> GetLopHoc()
        {
            try
            {
                return lopHocDL.GetLopHoc();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaGS()
        {
            return lopHocDL.GetDanhSachMaGS();
        }
        public List<string> GetDanhSachMaPH()
        {
            return lopHocDL.GetDanhSachMaPH();
        }
        public List<string> GetDanhSachMaLH()
        {
            List<Hoc> danhSachHoc = hocDL.GetHoc(); // hoặc inject HocDL nếu đang dùng DI
            List<LopHoc> danhSachLop = lopHocDL.GetLopHoc();

            // Đếm số học viên mỗi lớp
            var soHocVienTheoLop = danhSachHoc
                .GroupBy(h => h.MaLH)
                .ToDictionary(g => g.Key, g => g.Count());

            // Lọc các lớp chưa đủ học viên
            var maLopChuaDu = danhSachLop
                .Where(lh => lh.TrangThai == "Hoạt động")
                .Where(lh =>
                {
                    int soDaCo = soHocVienTheoLop.ContainsKey(lh.MaLH) ? soHocVienTheoLop[lh.MaLH] : 0;
                    return soDaCo < lh.SoLuongHV;
                })
                .Select(lh => lh.MaLH)
                .ToList();

            return maLopChuaDu;
        }
        public List<LopHoc> TimKiemLopHoc(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return lopHocDL.TimKiemLopHoc(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool CoThamGiaLopHoc(string maHV, string maLH)
        {
            try
            {
                return lopHocDL.CoThamGiaLopHoc(maHV, maLH);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
        public bool ThemLopHoc(LopHoc lh, out string error)
        {
            error = "";
            var dsHopDongPH = hopDongPHDL.GetHopDongPH();
            var dsHopDongGS = hopDongGSDL.GetHopDongGS();

            //Kiểm tra nếu GS chưa ký hợp đồng
            var coHopDongGS = dsHopDongGS.Any(gs => gs.MaGS == lh.MaGS);
            if (!coHopDongGS)
            {
                error = "Gia sư chưa ký hợp đồng";
                return false;
            }

            //Kiểm tra nếu PH chưa ký hợp đồng
            var coHopDongPH = dsHopDongPH.Any(hd => hd.MaPH == lh.MaPH);
            if (!coHopDongPH)
            {
                error = "Phụ huynh chưa ký hợp đồng";
                return false;
            }

            if (string.IsNullOrWhiteSpace(lh.MaGS) ||
                string.IsNullOrWhiteSpace(lh.MaPH) ||
                string.IsNullOrWhiteSpace(lh.MonHoc) ||
                string.IsNullOrWhiteSpace(lh.SoBuoi.ToString()) ||
                string.IsNullOrWhiteSpace(lh.HocPhi.ToString()) ||
                string.IsNullOrWhiteSpace(lh.TrangThai) ||
                string.IsNullOrWhiteSpace(lh.SoLuongHV.ToString()) ||
                string.IsNullOrWhiteSpace(lh.YeuCau))
            {
                error = "Thiếu thông tin";
                return false;
            }

            // Kiểm tra số lượng học viên thực tế của phụ huynh
            int soLuongHVThucTe = hocVienDL.GetHocVien().Count(hv => hv.MaPH == lh.MaPH);
            if (lh.SoLuongHV > soLuongHVThucTe)
            {
                error = "Số lượng học viên vượt quá thực tế";
                return false;
            }
            return lopHocDL.ThemLopHoc(lh);
        }
        public bool CapNhatLopHoc(LopHoc lh, out string error)
        {
            error = "";

            // Kiểm tra số học viên hiện tại so với số lượng cho phép
            var dsHoc = hocDL.GetHoc();
            int soLuongHienTai = dsHoc.Count(h => h.MaLH == lh.MaLH);

            if (soLuongHienTai > lh.SoLuongHV)
            {
                error = $"Để cập nhật số lượng, hãy hủy ở mục Học Viên";
                return false;
            }

            var dsHopDongPH = hopDongPHDL.GetHopDongPH();
            var dsHopDongGS = hopDongGSDL.GetHopDongGS();

            //Kiểm tra nếu GS chưa ký hợp đồng
            var coHopDongGS = dsHopDongGS.Any(gs => gs.MaGS == lh.MaGS);
            if (!coHopDongGS)
            {
                error = "Gia sư chưa ký hợp đồng";
                return false;
            }

            //Kiểm tra nếu PH chưa ký hợp đồng
            var coHopDongPH = dsHopDongPH.Any(hd => hd.MaPH == lh.MaPH);
            if (!coHopDongPH)
            {
                error = "Phụ huynh chưa ký hợp đồng";
                return false;
            }

            if (string.IsNullOrWhiteSpace(lh.MaGS) ||
            string.IsNullOrWhiteSpace(lh.MaPH) ||
            string.IsNullOrWhiteSpace(lh.MonHoc) ||
            string.IsNullOrWhiteSpace(lh.SoBuoi.ToString()) ||
            string.IsNullOrWhiteSpace(lh.HocPhi.ToString()) ||
            string.IsNullOrWhiteSpace(lh.TrangThai) ||
            string.IsNullOrWhiteSpace(lh.SoLuongHV.ToString()) ||
            string.IsNullOrWhiteSpace(lh.YeuCau))
            {
                return false;
            }

            // Kiểm tra số lượng học viên thực tế của phụ huynh
            int soLuongHVThucTe = hocVienDL.GetHocVien().Count(hv => hv.MaPH == lh.MaPH);
            if (lh.SoLuongHV > soLuongHVThucTe)
            {
                error = "Số lượng học viên vượt quá thực tế";
                return false;
            }
            return lopHocDL.CapNhatLopHoc(lh);

        }
    }
}
