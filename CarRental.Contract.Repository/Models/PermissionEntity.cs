using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("Permission")]
    public class PermissionEntity : Entity
    {
        public string IDPermission { get; set; }
        public string PermissionGroupName { get; set; }
        public virtual ICollection<UserPermissionEntity>? UserPermissions { get; set; }
        public virtual ICollection<PermissionDetailEntity>? PermissionDetails { get; set; }
    }
}
