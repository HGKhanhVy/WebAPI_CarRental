using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.UserPermission;
using CarRental.Core.Models.Xe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IXeService :
       Base.ICreateable<XeModel, string>,
       Base.IUpdateable<XeModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<XeEntity, string>,
       Base.ICounteable<XeModel, int>
    {
        public int getIDXe();
    }
}
