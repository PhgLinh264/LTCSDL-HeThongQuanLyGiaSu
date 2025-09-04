using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("GiaSu")]
    public class GiaSu
    {
        public GiaSu()
        {
            this.LopHocs = new HashSet<LopHoc>();
        }
        [Key] public string MaGS { get; set; }
        [Required][MaxLength(100)] public string HoTen { get; set; }
        [Required][MaxLength(15)] public string SDT { get; set; }
        [Required][MaxLength(100)] public string DiaChi { get; set; }
        [Required][MaxLength(10)] public string GioiTinh { get; set; }
        [Required] public System.DateTime NgaySinh { get; set; }
        [Required][MaxLength(100)] public string DaiHoc { get; set; }
        [Required][MaxLength(20)] public string MonDay { get; set; }
        [Required][MaxLength(20)] public string TrangThai { get; set; }
        [MaxLength(10)] public string XepHang { get; set; }

        //public virtual HopDongG HopDongG { get; set; }
        public virtual ICollection<LopHoc> LopHocs { get; set; }
    }
}
