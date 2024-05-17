using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("NhacHen")]
    public class NhacHenEntity : Entity
    {
        // Khóa chính
        public string IDNhacHen { get; set; }
        public int DinhKyNhacHen { get; set; }
        public string NDNhacHen { get; set; }
    }
}
