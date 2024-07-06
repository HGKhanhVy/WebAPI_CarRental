using CarRental.Contract.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface ICheckLichXe<T> where T : class, new()
    {
        Task<ICollection<XeEntity>> XeKhongCoLichAsync(string ThoiGianBatDau, string ThoiGianKetThuc);
        Boolean CheckLichXeAsync(string id, string ThoiGianBatDau, string ThoiGianKetThuc);
    }
}
