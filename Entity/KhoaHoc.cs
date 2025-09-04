using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("KhoaHoc")]
    public class KhoaHoc
    {
        public KhoaHoc()
        {
            this.DangKyKHs = new HashSet<DangKyKH>();
            this.ThamGiaKHs = new HashSet<ThamGiaKH>();
            this.DanhGiaKHs = new HashSet<DanhGiaKH>();
            this.HocViens = new HashSet<HocVien>();
        }
        [Key] public string MaKH { get; set; }
        [Required][MaxLength(100)] public string TenKH { get; set; }
        [Required][MaxLength(100)] public string LinhVuc { get; set; }
        [Required][MaxLength(50)] public string ThoiGian { get; set; }
        [Required] public int HocPhi { get; set; }
        [Required][MaxLength(50)] public string TrangThai { get; set; }
        [ForeignKey("DoiTac")][Required][MaxLength(20)] public string MaDT { get; set; }
        [ForeignKey("KhuyenMai")] public string MaKM { get; set; }
        public int TienKM { get; set; }

        public virtual ICollection<DangKyKH> DangKyKHs { get; set; }
        public virtual ICollection<ThamGiaKH> ThamGiaKHs { get; set; }
        public virtual ICollection<DanhGiaKH> DanhGiaKHs { get; set; }
        public virtual DoiTac DoiTac { get; set; }
        public virtual ICollection<HocVien> HocViens { get; set; }
        public virtual KhuyenMai KhuyenMai { get; set; }
    }
}
