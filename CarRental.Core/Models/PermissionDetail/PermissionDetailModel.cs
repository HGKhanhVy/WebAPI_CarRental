using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.PermissionDetail
{
    public class PermissionDetailModel
    {
        public string IDPermissionDetail { get; set; }

        // Khóa ngoại Permission
        public string IDPermission { get; set; }

        public string ActionCode { get; set; }
        public int CheckAction { get; set; }
    }
}
