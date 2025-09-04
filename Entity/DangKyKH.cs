using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("DangKyKH")]
    public class DangKyKH
    {
        [Key]
        [ForeignKey("PhuHuynh")] public string MaPH { get; set; }
        [ForeignKey("KhoaHoc")] public string MaKH { get; set; }
        public System.DateTime NgayDangKy { get; set; }
        public int SoLuongHV { get; set; }

        public virtual KhoaHoc KhoaHoc { get; set; }
        public virtual PhuHuynh PhuHuynh { get; set; }

    }
}
