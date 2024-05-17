using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.TrangThaiBaoDuong;
using CarRental.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IUserService :
       Base.ICreateable<UserModel, string>,
       Base.IUpdateable<UserModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<UserEntity, string>,
       Base.ICounteable<UserModel, int>,
       Base.ILogin<UserEntity, string, string>
    {
    }
}
