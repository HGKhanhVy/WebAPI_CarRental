using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IDeleteableByAnotherID<in TKey, in T2Key>
    {
        Task DeleteByAnotherIDAsync(TKey id, T2Key isPhysical, CancellationToken cancellationToken = default);
    }
}
