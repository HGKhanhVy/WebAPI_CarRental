using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("PermissionDetail")]
    public class PermissionDetailEntity : Entity
    {
        public string IDPermissionDetail { get; set; }

        // Khóa ngoại Permission
        public string IDPermission { get; set; }
        public virtual PermissionEntity Permissions { get; set; }

        public string ActionCode { get; set; }
        public int CheckAction { get; set; }
    }
}
