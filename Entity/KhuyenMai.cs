using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("KhuyenMai")]
    public class KhuyenMai
    {
        public KhuyenMai()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
            this.LopHocs = new HashSet<LopHoc>();
        }
        [Key] public string MaKM { get; set; }
        [Required] public int PhanTram { get; set; }
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
