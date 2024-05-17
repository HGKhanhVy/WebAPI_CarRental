using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.HopDongThueXe;
using CarRental.Core.Models.KhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IKhachHangService :
       Base.ICreateable<KhachHangModel, string>,
       Base.IUpdateable<KhachHangModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KhachHangEntity, string>,
       Base.ICounteable<KhachHangModel, int>,
       Base.ILogin<KhachHangEntity, string, string>
    {
    }
}
