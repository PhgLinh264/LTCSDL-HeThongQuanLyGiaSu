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
    public class KhuyenMaiKhoaHoc_BL
    {
        private KhuyenMaiKhoaHoc_DL kmKhoaHoc_DL;
        public KhuyenMaiKhoaHoc_BL()
        {
            kmKhoaHoc_DL = new KhuyenMaiKhoaHoc_DL();
        }
        public List<KhoaHoc> GetKhoaHoc()
        {
            try
            {
                return kmKhoaHoc_DL.GetKhoaHoc();
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
                return kmKhoaHoc_DL.GetDanhSachMaKH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<KhoaHoc> TimKiem(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return kmKhoaHoc_DL.TimKiem(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public bool CapNhatKhuyenMai(KhoaHoc kh)
        {
            if (string.IsNullOrEmpty(kh.MaKM))
                return false;

            var khoaHocHienTai = kmKhoaHoc_DL.GetKhoaHocByMaKH(kh.MaKH);
            //if (lopHocHienTai == null || lopHocHienTai.TrangThai == "Ngưng")
            //    return false;

            // Kiểm tra nếu lớp học đã có đúng khuyến mãi đó rồi thì không cần cập nhật
            if (khoaHocHienTai != null && khoaHocHienTai.MaKM == kh.MaKM)
                return true;

            return kmKhoaHoc_DL.CapNhatKhuyenMai(kh);
        }
        public bool XoaKhuyenMaiKhoiKhoaHoc(string maKH)
        {
            if (string.IsNullOrEmpty(maKH))
                return false;

            //var lop = kmLopHoc_DL.GetLopHocByMaLH(maLH);
            //if (lop == null || lop.TrangThai == "Ngưng")
            //    return false;

            return kmKhoaHoc_DL.XoaKhuyenMaiKhoiKhoaHoc(maKH);
        }
    }
}
