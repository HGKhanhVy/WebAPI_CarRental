using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Contract.Repository.Infrastructure;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Repository.Infrastructure;

namespace CarRental.Repository
{
    [ScopedDependency(ServiceType = typeof(ISoDienThoaiRepository))]
    public class SoDienThoaiRepository : Repository<SoDienThoaiEntity>, ISoDienThoaiRepository
    {
        public SoDienThoaiRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
