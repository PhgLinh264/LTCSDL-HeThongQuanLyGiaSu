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
    public class HocBL
    {
        private HocDL hocDL;
        private LopHocDL lopHocDL = new LopHocDL();
        private DanhGiaLH_DL danhGiaLHDL = new DanhGiaLH_DL();
        public HocBL()
        {
            hocDL = new HocDL();
        }
        public List<Hoc> GetHoc()
        {
            try
            {
                return hocDL.GetHoc();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<Hoc> TimKiemHoc(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return hocDL.TimKiemHoc(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<HocVien> GetDanhSachHocVienTheoMaPH(string maPH)
        {
            if (string.IsNullOrWhiteSpace(maPH))
                return new List<HocVien>();

            return hocDL.GetDanhSachHocVienTheoMaPH(maPH);
        }
        public bool CapNhatHoc(Hoc h, out string error)
        {
            error = "";

            var hocCu = hocDL.GetHoc().FirstOrDefault(p => p.MaLH == h.MaLH && p.MaHV == h.MaHV);
            if (hocCu != null) // nếu có hocCu
            {
                error = "Trùng thông tin";
                return false;
            }
            if (string.IsNullOrEmpty(h.MaLH) || string.IsNullOrEmpty(h.MaHV))
            {
                error = "Thiếu thông tin";
                return false;
            }

            var lopHoc = lopHocDL.GetLopHoc().FirstOrDefault(l => l.MaLH == h.MaLH);
            if (lopHoc == null)
            {
                error = "Chưa THÊM, không thể CẬP NHẬT";
                return false;
            }

            //var hocVienDangHocLopKhac = (from hocItem in hocDL.GetHoc()
            //                             join lh in lopHocDL.GetLopHoc() on hocItem.MaLH equals lh.MaLH
            //                             where hocItem.MaHV == h.MaHV
            //                                   && hocItem.MaLH != h.MaLH
            //                                   && lh.TrangThai == "Hoạt động"
            //                             select hocItem).Any();

            //if (hocVienDangHocLopKhac)
            //{
            //    error = "Học viên đang học lớp khác";
            //    return false;
            //}

            return hocDL.CapNhatHoc(h);
        }
        public bool XoaDangKyHoc(string maLH, string maHV)
        {
            //Kiểm tra nếu đã đánh giá lớp học rồi => không xóa
            var danhGiaList = danhGiaLHDL.GetDanhGiaLH();
            bool daDanhGia = danhGiaList.Any(dg => dg.MaLH == maLH && dg.MaHV == maHV);
            if (daDanhGia)
                return false;

            return hocDL.XoaDangKyHoc(maLH, maHV);
        }
    }
}
