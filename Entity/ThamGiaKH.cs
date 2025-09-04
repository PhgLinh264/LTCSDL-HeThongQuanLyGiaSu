using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("ThamGiaKH")]
    public class ThamGiaKH
    {
        [Key]
        [ForeignKey("KhoaHoc")] public string MaKH { get; set; }
        [ForeignKey("HocVien")] public string MaHV { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual KhoaHoc KhoaHoc { get; set; }

        //[NotMapped]
        //public string MaDK => $"{MaPH}_{MaKH}";
    }
}
