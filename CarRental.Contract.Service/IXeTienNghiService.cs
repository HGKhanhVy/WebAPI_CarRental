using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.UserPermission;
using CarRental.Core.Models.Xe;
using CarRental.Core.Models.XeTienNghi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IXeTienNghiService :
       Base.ICreateable<XeTienNghiModel, string>,
       Base.IUpdateable2Fields<XeTienNghiModel, string, string>,
       Base.IDeleteable2Fields<string, string, bool>,
       Base.IGetable2Fields<XeTienNghiEntity, string, string>,
       Base.ICounteable<XeTienNghiModel, int>,
       Base.ICreateableList<string, string>
    {
    }
}
