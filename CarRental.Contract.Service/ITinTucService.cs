using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.TinTuc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface ITinTucService :
    Base.ICreateable<TinTucModel, string>,
       Base.IUpdateable<TinTucModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<TinTucEntity, string>
    {
    }
}
