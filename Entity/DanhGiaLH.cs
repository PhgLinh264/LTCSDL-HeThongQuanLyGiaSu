using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("DanhGiaLH")]
    public class DanhGiaLH
    {
        [Key]
        [ForeignKey("PhuHuynh")] public string MaPH { get; set; }
        [Key]
        [ForeignKey("HocVien")] public string MaHV { get; set; }
        [Key]
        [ForeignKey("LopHoc")] public string MaLH { get; set; }
        public double DiemHV { get; set; }
        public double DiemDGLH { get; set; }
        public string LoaiDGLH { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual LopHoc LopHoc { get; set; }
        public virtual PhuHuynh PhuHuynh { get; set; }
    }
}
