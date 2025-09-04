using Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class QuanLyGiaSuContext : DbContext
    {
        public QuanLyGiaSuContext():base("name=QuanLyGiaSuContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hoc>().HasKey(h => new { h.MaLH, h.MaHV });
            modelBuilder.Entity<DangKyKH>().HasKey(dk => new { dk.MaPH, dk.MaKH });
            modelBuilder.Entity<ThamGiaKH>().HasKey(tg => new { tg.MaKH, tg.MaHV });
            modelBuilder.Entity<DanhGiaLH>().HasKey(dg => new { dg.MaPH, dg.MaHV, dg.MaLH });
            modelBuilder.Entity<DanhGiaKH>().HasKey(dg => new { dg.MaPH, dg.MaHV, dg.MaKH });

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<PhuHuynh> PhuHuynhs { get; set; }
        public virtual DbSet<DangKyKH> DangKyKHs { get; set; }
        public virtual DbSet<DanhGiaKH> DanhGiaKHs { get; set; }
        public virtual DbSet<DanhGiaLH> DanhGiaLHs { get; set; }
        public virtual DbSet<DoiTac> DoiTacs { get; set; }
        public virtual DbSet<GiaSu> GiaSus { get; set; }
        public virtual DbSet<Hoc> Hocs { get; set; }
        public virtual DbSet<HocVien> HocViens { get; set; }
        public virtual DbSet<HopDongGS> HopDongGSs { get; set; }
        public virtual DbSet<HopDongPH> HopDongPHs { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LopHoc> LopHocs { get; set; }
        public virtual DbSet<ThamGiaKH> ThamGiaKHs { get; set; }
    }
}
