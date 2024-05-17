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
using CarRental.Contract.Repository.Interface;

namespace CarRental.Repository
{
    [ScopedDependency(ServiceType = typeof(ILoginRepository))]
    public class LoginRepository : Repository<LoginEntity>, ILoginRepository
    {
        public LoginRepository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
