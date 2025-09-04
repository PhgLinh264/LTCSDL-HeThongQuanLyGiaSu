using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("PhuHuynh")]
    public class PhuHuynh
    {
        public PhuHuynh()
        {
            this.HocViens = new HashSet<HocVien>();
            this.DangKyKHs = new HashSet<DangKyKH>();
            this.DanhGiaKHs = new HashSet<DanhGiaKH>();
            this.LopHocs = new HashSet<LopHoc>();
            this.DanhGiaLHs = new HashSet<DanhGiaLH>();
        }
        [Key] public string MaPH { get; set; }
        [Required][MaxLength(100)] public string HoTen { get; set; }
        [Required][MaxLength(15)] public string SDT { get; set; }
        [Required][MaxLength(250)] public string DiaChi { get; set; }
        [Required][MaxLength(50)] public string TrangThai { get; set; }
        [Required][MaxLength(100)] public string Email { get; set; }

        public virtual ICollection<HocVien> HocViens { get; set; }
        public virtual ICollection<DangKyKH> DangKyKHs { get; set; }
        public virtual ICollection<DanhGiaKH> DanhGiaKHs { get; set; }
        public virtual HopDongPH HopDongPH { get; set; }
        public virtual ICollection<LopHoc> LopHocs { get; set; }
        public virtual ICollection<DanhGiaLH> DanhGiaLHs { get; set; }
    }
}
