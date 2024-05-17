using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.XeTienNghi
{
    public class XeTienNghiModel
    {
        // Khóa chính 2 thuộc tính (IDXe + IDTienNghi)
        // Khóa ngoại Xe 
        public string IDXe { get; set; }

        // Khóa ngoại TienNghi
        public string IDTienNghi { get; set; }
    }
}
