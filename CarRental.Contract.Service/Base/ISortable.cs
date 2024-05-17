using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Login;

namespace CarRental.Contract.Service.Base
{
    public interface ISortable<T> where T : class
    {
        List<T> SortOrderByAsyn();
        List<T> SortOrderByDescendingAsyn();
    }
}
