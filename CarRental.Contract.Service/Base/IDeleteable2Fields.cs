using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IDeleteable2Fields<in TKey, in T2Key, in T3Key>
    {
        Task DeleteAsync(TKey id, T2Key id_Ngoai, T3Key isPhysical, CancellationToken cancellationToken = default);
    }
}
