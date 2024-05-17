using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("TienNghi")]
    public class TienNghiEntity : Entity
    {
        // Khóa chính
        public string IDTienNghi { get; set; }
        public string TenTienNghi { get; set; }

        public virtual ICollection<XeTienNghiEntity>? XeTienNghis { get; set; }
    }
}
