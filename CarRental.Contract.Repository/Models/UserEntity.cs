using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("User")]
    public class UserEntity : Entity
    {
        public string IDUser { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public virtual ICollection<UserPermissionEntity>? UserPermissions { get; set; }
    }
}
