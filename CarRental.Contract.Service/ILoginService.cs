using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;

namespace CarRental.Contract.Service
{
    public interface ILoginService :
       Base.ICreateable<LoginModel, string>
    {
    }
}
