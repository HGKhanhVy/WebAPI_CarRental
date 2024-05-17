using Azure.Core;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface ITokenService :
        Base.ISaveTokenDB
    {
    }
}
