using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HopDongThueXe;
using CarRental.Core.Models.KhuyenMai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IKhuyenMaiService :
       Base.ICreateable<KhuyenMaiModel, string>,
       Base.IUpdateable<KhuyenMaiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KhuyenMaiEntity, string>,
       Base.ICounteable<KhuyenMaiModel, int>,
       Base.IPrintByID<KhuyenMaiEntity, string>
    {
    }
}
