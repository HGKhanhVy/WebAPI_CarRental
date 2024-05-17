using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("SoDienThoai")]
    public class SoDienThoaiEntity : Entity
    {
        public string DauSo { get; set; }
    }
}
