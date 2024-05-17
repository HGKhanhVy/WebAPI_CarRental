using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Repository.Models
{
    [Table("RefreshToken")]
    public class RefreshTokenEntity : Entity
    {
        [ForeignKey("Token")]
        public string Token { get; set; }
        public virtual TokenEntity? StrToken { get; set; }

        [ForeignKey("User")]
        public string IDUser { get; set; }

        public string JwtID { get; set; }

        // set trong code
        public bool IsUsed { get; set; }
        public bool IsRevoked { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
