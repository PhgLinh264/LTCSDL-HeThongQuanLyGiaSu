using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("DanhGiaKH")]
    public class DanhGiaKH
    {
        [Key]
        [ForeignKey("PhuHuynh")] public string MaPH { get; set; }
        [ForeignKey("HocVien")] public string MaHV { get; set; }
        [ForeignKey("KhoaHoc")] public string MaKH { get; set; }
        public double DiemKyNangHV { get; set; }
        public double DiemDGKH { get; set; }
        public string LoaiDGKH { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }
        public virtual PhuHuynh PhuHuynh { get; set; }
    }
}
