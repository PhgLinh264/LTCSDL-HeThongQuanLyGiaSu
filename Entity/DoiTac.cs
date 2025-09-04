using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [Table("DoiTac")]
    public class DoiTac
    {
        public DoiTac()
        {
            this.KhoaHocs = new HashSet<KhoaHoc>();
        }
        [Key] public string MaDT { get; set; }
        [Required][MaxLength(100)] public string TenDT { get; set; }
        [Required][MaxLength(100)] public string Email { get; set; }
        [Required][MaxLength(50)] public string TrangThai { get; set; }

        public virtual ICollection<KhoaHoc> KhoaHocs { get; set; }
    }
}
