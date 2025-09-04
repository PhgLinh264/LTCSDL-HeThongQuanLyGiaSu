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
    public class KhoaHocBL
    {
        private KhoaHocDL khoaHocDL;

        public KhoaHocBL()
        {
            khoaHocDL = new KhoaHocDL();
        }
        public List<KhoaHoc> GetKhoaHoc()
        {
            try
            {
                return khoaHocDL.GetKhoaHoc();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<string> GetDanhSachMaDT()
        {
            try
            {
                return khoaHocDL.GetDanhSachMaDT();
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }
        public List<KhoaHoc> TimKiemKhoaHoc(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return null;
            try
            {
                return khoaHocDL.TimKiemKhoaHoc(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemKhoaHoc(KhoaHoc kh)
        {
            if (string.IsNullOrWhiteSpace(kh.TenKH) ||
                string.IsNullOrWhiteSpace(kh.LinhVuc) ||
                string.IsNullOrWhiteSpace(kh.ThoiGian) ||
                string.IsNullOrWhiteSpace(kh.HocPhi.ToString()) ||
                string.IsNullOrWhiteSpace(kh.TrangThai) ||
                string.IsNullOrWhiteSpace(kh.MaDT))
            {
                return false;
            }
            else
            {
                return khoaHocDL.ThemKhoaHoc(kh);
            }
        }
        public bool CapNhatKhoaHoc(KhoaHoc kh)
        {
            if (string.IsNullOrWhiteSpace(kh.TenKH) ||
                string.IsNullOrWhiteSpace(kh.LinhVuc) ||
                string.IsNullOrWhiteSpace(kh.ThoiGian) ||
                string.IsNullOrWhiteSpace(kh.HocPhi.ToString()) ||
                string.IsNullOrWhiteSpace(kh.TrangThai) ||
                string.IsNullOrWhiteSpace(kh.MaDT))
            {
                return false;
            }
            else
            {
                return khoaHocDL.CapNhatKhoaHoc(kh);
            }
        }
    }
}
