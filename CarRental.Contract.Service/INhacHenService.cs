using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.LoaiXe;
using CarRental.Core.Models.NhacHen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface INhacHenService :
       Base.ICreateable<NhacHenModel, string>,
       Base.IUpdateable<NhacHenModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<NhacHenEntity, string>,
       Base.ICounteable<NhacHenModel, int>
    {
    }
}
