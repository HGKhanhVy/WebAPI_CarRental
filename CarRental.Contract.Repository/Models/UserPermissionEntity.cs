using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("UserPermission")]
    public class UserPermissionEntity : Entity
    {
        // Khóa ngoại User 
        public string IDUser { get; set; }
        public virtual UserEntity Users { get; set; }

        // Khóa ngoại Permission
        public string IDPermission { get; set; }
        public virtual PermissionEntity Permissions { get; set; }

    }
}
