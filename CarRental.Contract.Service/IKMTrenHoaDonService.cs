using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.KMLoaiXe;
using CarRental.Core.Models.KMTrenHoaDon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IKMTrenHoaDonService :
       Base.ICreateable<KMTrenHoaDonModel, string>,
       Base.IUpdateable<KMTrenHoaDonModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<KMTrenHoaDonEntity, string>,
       Base.ICounteable<KMTrenHoaDonModel, int>,
       Base.IPrintByID<KMTrenHoaDonEntity, string>,
       Base.IUpdateStatus
    {
    }
}
