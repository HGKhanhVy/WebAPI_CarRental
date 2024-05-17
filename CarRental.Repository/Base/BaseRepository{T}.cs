using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using CarRental.Contract.Repository.IBase;
using CarRental.Contract.Repository.Infrastructure;
using CarRental.Contract.Repository.Models;
using CarRental.Core.Utils;
using System.Linq.Expressions;

namespace CarRental.Repository.Base
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
        protected readonly IDbContext DbContext;

        public BaseRepository(IDbContext dbContext)
        {
            DbContext = dbContext;
        }

        private DbSet<T> _dbSet;

        protected DbSet<T> DbSet
        {
            get
            {
                if (_dbSet != null)
                {
                    return _dbSet;
                }

                _dbSet = DbContext.Set<T>();
                return _dbSet;
            }
        }

        public virtual void RefreshEntity(T entity)
        {
            DbContext.Entry(entity).Reload();
        }

        public virtual T Add(T entity)
        {
            entity.TrangThai = null;
            entity = DbSet.Add(entity).Entity;
            return entity;
        }

        public virtual List<T> AddRange(params T[] entities)
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            List<T> list = new List<T>();
            foreach (T val in entities)
            {
                T item = Add(val);
                list.Add(item);
            }

            return list;
        }

        public virtual void Delete(T entity)
        {
            try
            {
                TryAttach(entity);
                DbSet.Remove(entity);
            }
            catch (Exception)
            {
                RefreshEntity(entity);
                throw;
            }
        }

        public virtual void Delete(T entity, bool isPhysicalDelete = false)
        {
            try
            {
                TryAttach(entity);
                if (!isPhysicalDelete)
                {
                    entity.TrangThai = ObjHelper.ReplaceNullOrDefault(entity.TrangThai, DateTimeOffset.UtcNow.ToString());
                    DbContext.Entry(entity).Property((x) => x.TrangThai).IsModified = true;
                }
                else
                {
                    DbSet.Remove(entity);
                }
            }
            catch (Exception)
            {
                RefreshEntity(entity);
                throw;
            }
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate, bool isPhysicalDelete = false)
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            List<T> list = (from x in Get(predicate, isPhysicalDelete)
                            select new T
                            {
                                Id = x.Id
                            }).ToList();
            foreach (T item in list)
            {
                item.TrangThai = utcNow.ToString();
                Delete(item, isPhysicalDelete);
            }
        }

        public virtual void DeleteWhere(List<string> ids, bool isPhysicalDelete = false)
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            foreach (string id in ids)
            {
                T entity = new T
                {
                    Id = id,
                    TrangThai = utcNow.ToString()
                };
                Delete(entity, isPhysicalDelete);
            }
        }

        public virtual void DeleteWhere(Expression<Func<T, bool>> predicate)
        {
            IEnumerable<T> enumerable = Get(predicate).AsEnumerable();
            foreach (T item in enumerable)
            {
                Delete(item);
            }
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();
            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = includeProperties;
                foreach (Expression<Func<T, object>> navigationPropertyPath in array)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            return predicate == null ? queryable : queryable.Where(predicate);
        }

        public virtual IQueryable<T> GetTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsTracking();
            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = includeProperties;
                foreach (Expression<Func<T, object>> navigationPropertyPath in array)
                {
                    queryable = queryable.Include(navigationPropertyPath);
                }
            }

            return predicate == null ? queryable : queryable.Where(predicate);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> source = DbSet.AsNoTracking();
            if (predicate != null)
            {
                source = source.Where(predicate);
            }

            includeProperties = includeProperties?.Distinct().ToArray();
            if (includeProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = includeProperties;
                foreach (Expression<Func<T, object>> navigationPropertyPath in array)
                {
                    source = source.Include(navigationPropertyPath);
                }
            }

            return isIncludeDeleted ? source.IgnoreQueryFilters() : source.Where((x) => x.TrangThai == null);
        }

        public virtual T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(predicate, includeProperties).FirstOrDefault();
        }

        public virtual T GetSingleTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return Get(predicate, includeProperties).FirstOrDefault();
        }

        public virtual IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = DbSet.AsNoTracking();
            foreach (Expression<Func<T, object>> navigationPropertyPath in includeProperties)
            {
                queryable = queryable.Include(navigationPropertyPath);
            }

            return queryable;
        }

        public virtual void Update(T entity, params Expression<Func<T, object>>[] changedProperties)
        {
            TryAttach(entity);
            changedProperties = changedProperties?.Distinct().ToArray();
            if (changedProperties?.Any() ?? false)
            {
                Expression<Func<T, object>>[] array = changedProperties;
                foreach (Expression<Func<T, object>> propertyExpression in array)
                {
                    DbContext.Entry(entity).Property(propertyExpression).IsModified = true;
                }
            }
            else
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void Update(T entity)
        {

            TryAttach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Update(T entity, params string[] changedProperties)
        {
            TryAttach(entity);
            changedProperties = changedProperties?.Distinct().ToArray();
            if (changedProperties?.Any() ?? false)
            {
                string[] array = changedProperties;
                foreach (string propertyName in array)
                {
                    DbContext.Entry(entity).Property(propertyName).IsModified = true;
                }
            }
            else
            {
                DbContext.Entry(entity).State = EntityState.Modified;
            }
        }

        public virtual void UpdateWhere(Expression<Func<T, bool>> predicate, T entityNewData, params Expression<Func<T, object>>[] changedProperties)
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            List<T> list = (from x in Get(predicate, false)
                            select new T
                            {
                                Id = x.Id
                            }).ToList();
            foreach (T item in list)
            {
                T val = entityNewData.Clone();
                val.Id = item.Id;
                Update(val, changedProperties);
            }
        }

        public virtual void UpdateWhere(Expression<Func<T, bool>> predicate, T entityNewData, params string[] changedProperties)
        {
            DateTimeOffset utcNow = DateTimeOffset.UtcNow;
            List<T> list = (from x in Get(predicate, false)
                            select new T
                            {
                                Id = x.Id
                            }).ToList();
            foreach (T item in list)
            {
                T val = entityNewData.Clone();
                val.Id = item.Id;
                Update(val, changedProperties);
            }
        }

        protected void TryAttach(T entity)
        {
            try
            {
                if (DbContext.Entry(entity).State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
            }
            catch
            {
            }
        }

        protected void GetEntityEntries(out List<EntityEntry> listEntryAdded, out List<EntityEntry> listEntryModified, out List<EntityEntry> listEntryDeleted)
        {
            List<EntityState> listState = new()
            {
                EntityState.Added,
                EntityState.Modified,
                EntityState.Deleted
            };
            List<EntityEntry> source = (from x in DbContext.ChangeTracker.Entries()
                                        where x.Entity is T && listState.Contains(x.State)
                                        select x).ToList();
            listEntryAdded = source.Where((x) => x.State == EntityState.Added).ToList();
            listEntryModified = source.Where((x) => x.State == EntityState.Modified).ToList();
            listEntryDeleted = source.Where((x) => x.State == EntityState.Deleted).ToList();
        }

        protected void GetEntities(out List<T> listEntityAdded, out List<T> listEntityModified, out List<T> listEntityDeleted)
        {
            GetEntityEntries(out var listEntryAdded, out var listEntryModified, out var listEntryDeleted);
            listEntityAdded = listEntryAdded.Cast<T>().ToList();
            listEntityModified = listEntryModified.Cast<T>().ToList();
            listEntityDeleted = listEntryDeleted.Cast<T>().ToList();
        }
    }
}
