using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ChucVu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IChucVuService :
       Base.ICreateable<ChucVuModel, string>,
       Base.IUpdateable<ChucVuModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<ChucVuEntity, string>,
       Base.ICounteable<ChucVuModel, int>,
       Base.IPrintByID<ChucVuEntity, string>
    {
    }
}
