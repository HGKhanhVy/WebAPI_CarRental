using CarRental.Contract.Repository.Infrastructure;
using CarRental.Contract.Repository.Interface;
using CarRental.Contract.Repository.Models;
using CarRental.Repository.Infrastructure;
using Invedia.DI.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Repository
{
    [ScopedDependency(ServiceType = typeof(IKhuyenMaiRepository))]
    public class KhuyenMaiRepository : Repository<KhuyenMaiEntity>, IKhuyenMaiRepository
    {
        public KhuyenMaiRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
