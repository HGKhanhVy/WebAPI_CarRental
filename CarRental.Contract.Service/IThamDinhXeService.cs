using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Room;
using CarRental.Core.Models.ThamDinhXe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface IThamDinhXeService :
       Base.ICreateable<ThamDinhXeModel, string>,
       Base.IUpdateable<ThamDinhXeModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<ThamDinhXeEntity, string>,
       Base.ICounteable<ThamDinhXeModel, int>
    {
    }
}
