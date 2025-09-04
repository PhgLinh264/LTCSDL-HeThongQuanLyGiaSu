using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("Hoc")]
    public class Hoc
    {
        [Key]
        [ForeignKey("LopHoc")] public string MaLH { get; set; }
        [ForeignKey("HocVien")] public string MaHV { get; set; }

        public virtual HocVien HocVien { get; set; }
        public virtual LopHoc LopHoc { get; set; }
    }
}
