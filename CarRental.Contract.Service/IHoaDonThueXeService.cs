using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HoaDonKyGui;
using CarRental.Core.Models.HoaDonThueXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IHoaDonThueXeService :
       Base.ICreateable<HoaDonThueXeModel, string>,
       Base.IUpdateable<HoaDonThueXeModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HoaDonThueXeEntity, string>,
       Base.ICounteable<HoaDonThueXeModel, int>,
       Base.IPrintByID<HoaDonThueXeEntity, string>
    {
    }
}
