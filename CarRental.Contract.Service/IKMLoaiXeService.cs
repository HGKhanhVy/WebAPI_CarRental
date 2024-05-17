using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMLoaiKH;
using CarRental.Core.Models.KMLoaiXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IKMLoaiXeService :
       Base.ICreateable<KMLoaiXeModel, string>,
       Base.IUpdateable<KMLoaiXeModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KMLoaiXeEntity, string>,
       Base.ICounteable<KMLoaiXeModel, int>,
       Base.IPrintByID<KMLoaiXeEntity, string>,
       Base.IUpdateStatus
    {
    }
}
