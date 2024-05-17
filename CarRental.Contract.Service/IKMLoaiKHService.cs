using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KhuyenMai;
using CarRental.Core.Models.KMLoaiKH;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IKMLoaiKHService :
       Base.ICreateable<KMLoaiKHModel, string>,
       Base.IUpdateable<KMLoaiKHModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KMLoaiKHEntity, string>,
       Base.ICounteable<KMLoaiKHModel, int>,
       Base.IPrintByID<KMLoaiKHEntity, string>,
       Base.IUpdateStatus
    {
    }
}
