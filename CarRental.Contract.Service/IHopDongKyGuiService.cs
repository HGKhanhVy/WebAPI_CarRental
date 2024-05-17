using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HoaDonThueXe;
using CarRental.Core.Models.HopDongKyGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IHopDongKyGuiService :
       Base.ICreateable<HopDongKyGuiModel, string>,
       Base.IUpdateable<HopDongKyGuiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HopDongKyGuiEntity, string>,
       Base.ICounteable<HopDongKyGuiModel, int>,
       Base.IPrintByID<HopDongKyGuiEntity, string>
    {
    }
}
