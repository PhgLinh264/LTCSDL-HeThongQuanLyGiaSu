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
    public class DanhGiaLH_BL
    {
        DanhGiaLH_DL danhgiaLH;
        HocDL hocDL = new HocDL();
        public DanhGiaLH_BL()
        {
            danhgiaLH = new DanhGiaLH_DL();
        }
        public List<DanhGiaLH> GetDanhGiaLH()
        {
            try
            {
                return danhgiaLH.GetDanhGiaLH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<DanhGiaLH> TimKiemDanhGiaLH(string tieuChi, string tuKhoa)
        {
            try
            {
                return danhgiaLH.TimKiemDanhGiaLH(tieuChi, tuKhoa);
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
                return danhgiaLH.GetDanhSachMaPH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetDanhSachMaHVTheoMaPH(string maPH)
        {
            try
            {
                return danhgiaLH.GetDanhSachMaHVTheoMaPH(maPH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetMaLHTheoMaHV(string maHV)
        {
            try
            {
                return danhgiaLH.GetMaLHTheoMaHV(maHV);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDanhGiaLH(DanhGiaLH dg)
        {

            if (string.IsNullOrWhiteSpace(dg.MaPH) ||
                string.IsNullOrWhiteSpace(dg.MaHV) ||
                string.IsNullOrWhiteSpace(dg.MaLH) ||
                string.IsNullOrWhiteSpace(dg.DiemHV.ToString()) ||
                string.IsNullOrWhiteSpace(dg.DiemDGLH.ToString()) ||
                string.IsNullOrWhiteSpace(dg.LoaiDGLH))
            {
                return false;
            }

            else
            {
                return danhgiaLH.ThemDanhGiaLH(dg);
            }
        }
        public bool XoaDanhGiaLH(string maPH, string maHV, string maLH)
        {
            try
            {
                return danhgiaLH.XoaDanhGiaLH(maPH, maHV, maLH);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
