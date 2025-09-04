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
    public  class GiaSuBL
    {
        GiaSuDL giaSuDL;
        public GiaSuBL()
        {
            giaSuDL = new GiaSuDL();  
        }
        public List<GiaSu> GetGiaSu()
        {
            try
            {
                return giaSuDL.GetGiaSu().ToList();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public List<GiaSu> TimKiemGiaSu(string tieuChi, string tuKhoa)
        {
            if (tuKhoa == null || tieuChi == null)
                return new List<GiaSu>();
            try
            {
                return giaSuDL.TimKiemGiaSu(tieuChi, tuKhoa);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public bool ThemGiaSu(GiaSu gs)
        {

            if (string.IsNullOrWhiteSpace(gs.HoTen) ||
                string.IsNullOrWhiteSpace(gs.SDT) ||
                string.IsNullOrWhiteSpace(gs.DiaChi) ||
                string.IsNullOrWhiteSpace(gs.DaiHoc) ||
                string.IsNullOrWhiteSpace(gs.MonDay) ||
                gs.NgaySinh.Date == DateTime.Now ||
                string.IsNullOrWhiteSpace(gs.GioiTinh))
            {
                return false;
            }
            else
            {
                return giaSuDL.ThemGiaSu(gs);
            }
        }
        public bool CapNhatGiaSu(GiaSu gs)
        {
            if (string.IsNullOrWhiteSpace(gs.HoTen) ||
                string.IsNullOrWhiteSpace(gs.SDT) ||
                string.IsNullOrWhiteSpace(gs.DiaChi) ||
                string.IsNullOrWhiteSpace(gs.DaiHoc) ||
                string.IsNullOrWhiteSpace(gs.MonDay) ||
                gs.NgaySinh.Date == DateTime.Now ||
                string.IsNullOrWhiteSpace(gs.GioiTinh))
            {
                return false;
            }
            else
            {
                return giaSuDL.CapNhatGiaSu(gs);
            }
        }
    }
}
