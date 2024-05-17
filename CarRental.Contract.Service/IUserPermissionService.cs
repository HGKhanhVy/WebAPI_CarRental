using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.User;
using CarRental.Core.Models.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IUserPermissionService :
       Base.ICreateable<UserPermissionModel, string>,
       Base.IUpdateable2Fields<UserPermissionModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<UserPermissionEntity, string, string>,
       Base.ICounteable<UserPermissionModel, int>
    {
    }
}
