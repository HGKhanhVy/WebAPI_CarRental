using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface ISaveTokenDB
    {
        int SaveTokenToDB(string accessToken, string refreshToken, string userName, string tokenID);
    }
}
