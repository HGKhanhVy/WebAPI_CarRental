using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface ILogin<T, in TKey, in T2Key> where T : class, new()
    {
        T NhanVienLogin(TKey email, T2Key mk);
        T KhachHangLogin(TKey email, T2Key mk);
    }
}
