using CarRental.Contract.Repository.IBase;
using CarRental.Contract.Repository.Infrastructure;
using CarRental.Contract.Repository.Models;
using CarRental.Repository.Base;

namespace CarRental.Repository.Infrastructure
{
    public abstract class Repository<T> : BaseRepository<T>, IRepository<T>, IBaseRepository<T> where T : Entity, new()
    {
        public Repository(IDbContext dbContext) : base(dbContext)
        {

        }
    }
}
