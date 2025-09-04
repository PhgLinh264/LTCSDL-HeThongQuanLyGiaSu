using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("HocVien")]
    public class HocVien
    {
        public HocVien()
        {
            this.DanhGiaKHs = new HashSet<DanhGiaKH>();
            this.KhoaHocs = new HashSet<KhoaHoc>();
            this.Hocs = new HashSet<Hoc>();
            this.ThamGiaKHs = new HashSet<ThamGiaKH>();
            this.DanhGiaLHs = new HashSet<DanhGiaLH>();
        }

        [Key] public string MaHV { get; set; }
        [ForeignKey("PhuHuynh")][Required][MaxLength(100)] public string MaPH { get; set; }
        [Required][MaxLength(100)] public string HoTen { get; set; }
        [Required][MaxLength(10)] public string GioiTinh { get; set; }
        [Required] public System.DateTime NgaySinh { get; set; }
        [Required][MaxLength(10)] public string HocLuc { get; set; }


        public virtual PhuHuynh PhuHuynh { get; set; }
        public virtual ICollection<DanhGiaKH> DanhGiaKHs { get; set; }
        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
        public virtual ICollection<Hoc> Hocs { get; set; }
        public virtual ICollection<ThamGiaKH> ThamGiaKHs { get; set; }
        public virtual ICollection<DanhGiaLH> DanhGiaLHs { get; set; }
    }
}
