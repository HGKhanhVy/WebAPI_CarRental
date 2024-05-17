using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("LoaiXe")]
    public class LoaiXeEntity : Entity
    {
        // Khóa chính
        public string IDLoaiXe { get; set; }
        public string TenLoaiXe { get; set; }
        public double GiaThue { get; set; }

        public KMLoaiXeEntity? KMLoaiXes { get; set; }
        public virtual ICollection<XeEntity>? Xes { get; set; }
    }
}
