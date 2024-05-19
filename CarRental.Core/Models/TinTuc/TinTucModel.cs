using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.TinTuc
{
    public class TinTucModel
    {
        public string IDTinTuc { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public string HinhAnh { get; set; }
        public string NguoiTao { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
