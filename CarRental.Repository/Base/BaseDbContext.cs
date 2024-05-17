using Microsoft.EntityFrameworkCore;
using CarRental.Contract.Repository.Infrastructure;

namespace CarRental.Repository.Base
{
    public abstract class BaseDbContext : DbContext, IDbContext
    {
        protected BaseDbContext()
        {
            //Database.MigrateAsync(new CancellationToken()).Wait();
        }

        protected BaseDbContext(DbContextOptions options)
            : base(options)
        {
            //Database.MigrateAsync(new CancellationToken()).Wait();
        }
    }
}
