using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IUpdateable2Fields<in T, in TKey1, in TKey2> where T : class, new()
    {
        Task UpdateAsync(TKey1 key, TKey2 key2, T model, CancellationToken cancellationToken = default);
    }
}
