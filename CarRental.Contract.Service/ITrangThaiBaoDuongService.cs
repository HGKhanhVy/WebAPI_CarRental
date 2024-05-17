using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.TienNghi;
using CarRental.Core.Models.TrangThaiBaoDuong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface ITrangThaiBaoDuongService :
       Base.ICreateable<TrangThaiBaoDuongModel, string>,
       Base.IUpdateable<TrangThaiBaoDuongModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<TrangThaiBaoDuongEntity, string>,
       Base.ICounteable<TrangThaiBaoDuongModel, int>
    {
    }
}
