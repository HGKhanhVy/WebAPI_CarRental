using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.UserPermission
{
    public class UserPermissionModel
    {
        public string IDUser { get; set; }

        // Khóa ngoại Permission
        public string IDPermission { get; set; }
    }
}
