using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.NhanVien;
using CarRental.Core.Models.PermissionDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IPermissionDetailService :
       Base.ICreateable<PermissionDetailModel, string>,
       Base.IUpdateable<PermissionDetailModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<PermissionDetailEntity, string>,
       Base.ICounteable<PermissionDetailModel, int>
    {
    }
}
