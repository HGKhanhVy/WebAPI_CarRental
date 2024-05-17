using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Core.Models.RefreshToken
{
    public class RefreshTokenModel
    {
        public string Token { get; set; }
        public string IDUser { get; set; }
        public string JwtID { get; set; }
    }
}
