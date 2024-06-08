using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface ICreateableList<Tkey, T2Key>
    {
        Task<string> CreateableList(Tkey keyId, T2Key[] id, CancellationToken cancellationToken = default);
    }
}
