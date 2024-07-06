using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IGetForKMLoaiXe<T, in TKey> where T : class, new()
    {
        ICollection<T> GetKMChuaCoAsync();
    }
}
