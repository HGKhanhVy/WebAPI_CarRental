using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("Login")]
    public class LoginEntity : Entity
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
    }
}
