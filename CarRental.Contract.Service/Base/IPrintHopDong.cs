using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Contract.Service.Base
{
    public interface IPrintHopDong<in T, TKey> where T : class, new()
    {
        FileContentResult PrintHopDong(TKey id);
    }
}
