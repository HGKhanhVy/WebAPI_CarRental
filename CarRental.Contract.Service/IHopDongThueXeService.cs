using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HopDongKyGui;
using CarRental.Core.Models.HopDongThueXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IHopDongThueXeService :
       Base.ICreateable<HopDongThueXeModel, string>,
       Base.IUpdateable<HopDongThueXeModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HopDongThueXeEntity, string>,
       Base.ICounteable<HopDongThueXeModel, int>,
       Base.IPrintByID<HopDongThueXeEntity, string>
    {
    }
}
