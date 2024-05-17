using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMVoucher;
using CarRental.Core.Models.LichXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface ILichXeService :
       Base.ICreateable<LichXeModel, string>,
       Base.IUpdateable<LichXeModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<LichXeEntity, string>,
       Base.ICounteable<LichXeModel, int>,
       Base.IPrintByID<LichXeEntity, string>,
       Base.IUpdateStatus
    {
    }
}
