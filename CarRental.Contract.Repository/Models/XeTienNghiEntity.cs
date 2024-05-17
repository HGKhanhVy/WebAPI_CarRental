using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("XeTienNghi")]
    public class XeTienNghiEntity : Entity
    {
        // Khóa chính 2 thuộc tính (IDXe + IDTienNghi)
        // Khóa ngoại Xe 
        public string IDXe { get; set; }
        public virtual XeEntity Xes { get; set; }

        // Khóa ngoại TienNghi
        public string IDTienNghi { get; set; }
        public virtual TienNghiEntity TienNghis { get; set; }

    }
}
