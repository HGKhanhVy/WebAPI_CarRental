using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.SoDienThoai;

namespace CarRental.Contract.Service
{
    public interface ISoDienThoaiService :
       Base.ICreateable<SoDienThoaiModel, string>,
       Base.IUpdateable<SoDienThoaiModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<SoDienThoaiEntity, string>
    {
    }
}
