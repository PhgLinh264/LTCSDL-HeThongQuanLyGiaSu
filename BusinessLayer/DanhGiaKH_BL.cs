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
    public class DanhGiaKH_BL
    {
        DanhGiaKH_DL danhgiaKH;
        ThamGiaKH_DL thamGiaKHDL = new ThamGiaKH_DL();
        public DanhGiaKH_BL()
        {
            danhgiaKH = new DanhGiaKH_DL();
        }
        public List<DanhGiaKH> GetDanhGiaKH()
        {
            try
            {
                return danhgiaKH.GetDanhGiaKH();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<DanhGiaKH> TimKiemDanhGiaKH(string tieuChi, string tuKhoa)
        {
            try
            {
                return danhgiaKH.TimKiemDanhGiaKH(tieuChi, tuKhoa);
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
                return danhgiaKH.GetDanhSachMaPH();
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
                return danhgiaKH.GetDanhSachMaHVTheoMaPH(maPH);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<string> GetMaKHTheoMaHV(string maHV)
        {
            try
            {
                return danhgiaKH.GetMaKHTheoMaHV(maHV);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemDanhGiaKH(DanhGiaKH dg)
        {
            if (string.IsNullOrWhiteSpace(dg.MaPH) ||
                string.IsNullOrWhiteSpace(dg.MaHV) ||
                string.IsNullOrWhiteSpace(dg.MaKH) ||
                string.IsNullOrWhiteSpace(dg.DiemKyNangHV.ToString()) ||
                string.IsNullOrWhiteSpace(dg.DiemDGKH.ToString()) ||
                string.IsNullOrWhiteSpace(dg.LoaiDGKH))
            {
                return false;
            }

            else
            {
                return danhgiaKH.ThemDanhGiaKH(dg);
            }
        }
        public bool XoaDanhGiaKH(string maPH, string maHV, string maKH)
        {
            try
            {
                return danhgiaKH.XoaDanhGiaKH(maPH, maHV, maKH);
            }
            catch (SqlException ex)
            {

                throw ex;
            }
        }
    }
}
