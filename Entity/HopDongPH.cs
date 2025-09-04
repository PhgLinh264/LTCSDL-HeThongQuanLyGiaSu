using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("HopDongPH")]
    public class HopDongPH
    {
        [Key, ForeignKey("PhuHuynh")] public string MaPH { get; set; }
        [Required] public System.DateTime NgayKy { get; set; }
        public Nullable<System.DateTime> NgayHuy { get; set; }
        [MaxLength(250)] public string LyDo { get; set; }

        public virtual PhuHuynh PhuHuynh { get; set; }
    }
}
