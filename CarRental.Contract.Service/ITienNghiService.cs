using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.ThanhLyHopDong;
using CarRental.Core.Models.TienNghi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface ITienNghiService :
       Base.ICreateable<TienNghiModel, string>,
       Base.IUpdateable<TienNghiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<TienNghiEntity, string>,
       Base.ICounteable<TienNghiModel, int>
    {
    }
}
