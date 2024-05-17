using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface ICheckToken
    {
        RefreshTokenEntity CheckExistsToken(TokenModel model);
    }
}
