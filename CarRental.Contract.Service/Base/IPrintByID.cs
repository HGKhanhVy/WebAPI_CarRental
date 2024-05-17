using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IPrintByID<in T, TKey> where T : class, new()
    {
        string PrintByIDAsync(TKey id);
    }
}
