using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ThamDinhXe;
using CarRental.Core.Models.ThanhLyHopDong;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IThanhLyHopDongService :
       Base.ICreateable<ThanhLyHopDongModel, string>,
       Base.IUpdateable<ThanhLyHopDongModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<ThanhLyHopDongEntity, string>,
       Base.ICounteable<ThanhLyHopDongModel, int>
    {
    }
}
