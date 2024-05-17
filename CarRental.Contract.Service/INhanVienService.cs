using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.NhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service
{
    public interface INhanVienService :
       Base.ICreateable<NhanVienModel, string>,
       Base.IUpdateable<NhanVienModel, string>,
       Base.IDeleteable<string, bool>,
       Base.IGetable<NhanVienEntity, string>,
       Base.ICounteable<NhanVienModel, int>,
       Base.ILogin<NhanVienEntity, string, string>
    {
    }
}
