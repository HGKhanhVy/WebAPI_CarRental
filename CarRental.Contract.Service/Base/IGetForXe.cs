using CarRental.Contract.Repository.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IGetForXe<T, in TKey> where T : class, new()
    {
        ICollection<T> GetAllSoTuDongAsync();
        ICollection<T> GetAllXeDienAsync();
        ICollection<T> GetAllSoSanAsync();
        ICollection<T> GetAllByHangXeAsync(string str);
        Task<ICollection<TienNghiEntity>> GetTienNghiXeAsync(TKey keyId);
    }
}
