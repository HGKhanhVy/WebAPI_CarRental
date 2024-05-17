using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IUpdateable<in T, in Tkey> where T : class, new()
    {
        Task UpdateAsync(Tkey key, T model, CancellationToken cancellationToken = default);
    }
}
