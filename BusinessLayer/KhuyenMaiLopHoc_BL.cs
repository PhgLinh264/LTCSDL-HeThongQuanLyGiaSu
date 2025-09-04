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
    public class KhuyenMaiLopHoc_BL
    {
        private KhuyenMaiLopHoc_DL kmLopHoc_DL;
        public KhuyenMaiLopHoc_BL()
        {
            kmLopHoc_DL = new KhuyenMaiLopHoc_DL();
        }
        public List<LopHoc> GetLopHoc()
        {
            try
            {
                return kmLopHoc_DL.GetLopHoc();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        
        public List<string> GetDanhSachMaLH()
        {
            try
            {
                return kmLopHoc_DL.GetDanhSachMaLH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<LopHoc> TimKiem(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return kmLopHoc_DL.TimKiem(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public bool CapNhatKhuyenMai(LopHoc lh)
        {
            if (string.IsNullOrEmpty(lh.MaKM))
                return false;

            var lopHocHienTai = kmLopHoc_DL.GetLopHocByMaLH(lh.MaLH);
            //if (lopHocHienTai == null || lopHocHienTai.TrangThai == "Ngưng")
            //    return false;

            // Kiểm tra nếu lớp học đã có đúng khuyến mãi đó rồi thì không cần cập nhật
            if (lopHocHienTai != null && lopHocHienTai.MaKM == lh.MaKM)
                return true;

            return kmLopHoc_DL.CapNhatKhuyenMai(lh);
        }
        public bool XoaKhuyenMaiKhoiLopHoc(string maLH)
        {
            if (string.IsNullOrEmpty(maLH))
                return false;

            //var lop = kmLopHoc_DL.GetLopHocByMaLH(maLH);
            //if (lop == null || lop.TrangThai == "Ngưng")
            //    return false;

            return kmLopHoc_DL.XoaKhuyenMaiKhoiLopHoc(maLH);
        }
    }
}
