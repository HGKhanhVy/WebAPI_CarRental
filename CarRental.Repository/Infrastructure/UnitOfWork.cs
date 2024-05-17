using Invedia.DI.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CarRental.Contract.Repository.Infrastructure;
using CarRental.Core.Utils;
using Entity = CarRental.Contract.Repository.Models.Entity;

namespace CarRental.Repository.Infrastructure
{
    [ScopedDependency(ServiceType = typeof(IUnitOfWork))]
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;
        private bool disposed = false;
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetRequiredService<IDbContext>();
        }
        #region Save
        public int SaveChange()
        {
            StandardizeEntities();
            return _dbContext.SaveChanges();
        }

        public Task<int> SaveChangeAsync()
        {
            StandardizeEntities();
            return _dbContext.SaveChangesAsync();
        }

        private void StandardizeEntities()
        {
            var listState = new List<EntityState>
            {
                EntityState.Added,
                EntityState.Modified,
                EntityState.Deleted
            };

            var listEntry = _dbContext.ChangeTracker.Entries()
                .Where(x => x.Entity is Entity && listState.Contains(x.State))
                .Select(x => x).ToList();

            var dateTimeNow = CoreHelper.SystemTimeNow;

            foreach (var entry in listEntry)
            {
                if (entry.Entity is Entity baseEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        baseEntity.TrangThai = null;
                    }
                    else
                    {
                        if (baseEntity.TrangThai != null)
                            baseEntity.TrangThai = ObjHelper.ReplaceNullOrDefault(baseEntity.TrangThai, dateTimeNow.ToString());
                    }
                }

                if (!(entry.Entity is Entity entity)) continue;

                //TODO
                //int? loggedInUserId = null;//LoggedInUser.Current?.Id;

                //if (entry.State == EntityState.Added)
                //{
                //    entity.CreatedBy = entity.LastUpdatedBy = entity.CreatedBy ?? loggedInUserId;
                //}
                //else
                //{
                //    if (entity.DeletedTime != null)
                //        entity.DeletedBy ??= loggedInUserId;
                //    else
                //        entity.LastUpdatedBy ??= loggedInUserId;
                //}
            }
        }
        #endregion Save
        #region Dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion Dispose
    }
}
