using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Permission;
using CarRental.Core.Models.PhongBan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IPhongBanService :
       Base.ICreateable<PhongBanModel, string>,
       Base.IUpdateable<PhongBanModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<PhongBanEntity, string>,
       Base.ICounteable<PhongBanModel, int>
    {
    }
}
