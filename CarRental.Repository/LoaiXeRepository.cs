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
    [ScopedDependency(ServiceType = typeof(ILoaiXeRepository))]
    public class LoaiXeRepository : Repository<LoaiXeEntity>, ILoaiXeRepository
    {
        public LoaiXeRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
