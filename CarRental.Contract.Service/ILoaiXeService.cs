using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.LoaiKhachHang;
using CarRental.Core.Models.LoaiXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface ILoaiXeService :
       Base.ICreateable<LoaiXeModel, string>,
       Base.IUpdateable<LoaiXeModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<LoaiXeEntity, string>,
       Base.ICounteable<LoaiXeModel, int>,
       Base.IPrintByID<LoaiXeEntity, string>
    {
    }
}
