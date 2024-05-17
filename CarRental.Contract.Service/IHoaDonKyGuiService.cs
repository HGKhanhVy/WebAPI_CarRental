using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ChucVu;
using CarRental.Core.Models.HoaDonKyGui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IHoaDonKyGuiService :
       Base.ICreateable<HoaDonKyGuiModel, string>,
       Base.IUpdateable<HoaDonKyGuiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<HoaDonKyGuiEntity, string>,
       Base.ICounteable<HoaDonKyGuiModel, int>,
       Base.IPrintByID<HoaDonKyGuiEntity, string>
    {
    }
}
