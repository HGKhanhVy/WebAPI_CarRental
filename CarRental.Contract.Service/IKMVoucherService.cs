using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMTrenHoaDon;
using CarRental.Core.Models.KMVoucher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IKMVoucherService :
       Base.ICreateable<KMVoucherModel, string>,
       Base.IUpdateable<KMVoucherModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KMVoucherEntity, string>,
       Base.ICounteable<KMVoucherModel, int>,
       Base.IPrintByID<KMVoucherEntity, string>,
       Base.IUpdateStatus
    {
    }
}
