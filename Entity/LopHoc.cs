using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("LopHoc")]
    public class LopHoc
    {
        public LopHoc()
        {
            this.Hocs = new HashSet<Hoc>();
            this.DanhGiaLHs = new HashSet<DanhGiaLH>();
        }
        [Key] public string MaLH { get; set; }
        [Required][MaxLength(100)] public string MonHoc { get; set; }
        [Required] public int SoBuoi { get; set; }
        [Required] public int HocPhi { get; set; }
        [Required][MaxLength(50)] public string TrangThai { get; set; }
        [ForeignKey("GiaSu")][Required][MaxLength(10)] public string MaGS { get; set; }
        [Required] public System.DateTime NgayNhanLop { get; set; }
        [ForeignKey("PhuHuynh")][Required][MaxLength(10)] public string MaPH { get; set; }
        [Required] public int SoLuongHV { get; set; }
        [Required] public System.DateTime NgayDangKy { get; set; }
        [Required][MaxLength(250)] public string YeuCau { get; set; }
        [ForeignKey("KhuyenMai")][MaxLength(10)] public string MaKM { get; set; }
        public int TienKM { get; set; }

        public virtual PhuHuynh PhuHuynh { get; set; }
        public virtual ICollection<DanhGiaLH> DanhGiaLHs { get; set; }
        public virtual KhuyenMai KhuyenMai { get; set; }
        public virtual GiaSu GiaSu { get; set; }
        public virtual ICollection<Hoc> Hocs { get; set; }
    }
}
