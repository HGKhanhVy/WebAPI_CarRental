using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.PhongBan;
using CarRental.Core.Models.QuanLyChuyenKhoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IQuanLyChuyenKhoanService :
       Base.ICreateable<QuanLyChuyenKhoanModel, string>,
       Base.IUpdateable<QuanLyChuyenKhoanModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<QuanLyChuyenKhoanEntity, string>,
       Base.ICounteable<QuanLyChuyenKhoanModel, int>
    {
    }
}
