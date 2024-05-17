using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.LichXe;
using CarRental.Core.Models.LoaiKhachHang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface ILoaiKhachHangService :
       Base.ICreateable<LoaiKhachHangModel, string>,
       Base.IUpdateable<LoaiKhachHangModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<LoaiKhachHangEntity, string>,
       Base.ICounteable<LoaiKhachHangModel, int>,
       Base.IPrintByID<LoaiKhachHangEntity, string>
    {
    }
}
