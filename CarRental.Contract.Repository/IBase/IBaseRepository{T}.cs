using CarRental.Contract.Repository.Models;
using System.Linq.Expressions;

namespace CarRental.Contract.Repository.IBase
{
    public interface IBaseRepository<T> where T : Entity, new()
    {
        void RefreshEntity(T entity);

        IQueryable<T> Include(params Expression<Func<T, object>>[] includeProperties);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, bool isIncludeDeleted = false, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> GetTracking(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);
        T GetSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);
        T GetSingleTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        T Add(T entity);

        List<T> AddRange(params T[] entities);

        void Update(T entity, params Expression<Func<T, object>>[] changedProperties);
        void Update(T entity, params string[] changedProperties);
        void Update(T entity);
        void UpdateWhere(Expression<Func<T, bool>> predicate, T entityNewData, params Expression<Func<T, object>>[] changedProperties);
        void UpdateWhere(Expression<Func<T, bool>> predicate, T entityNewData, params string[] changedProperties);
        void Delete(T entity);
        void Delete(T entity, bool isPhysicalDelete = false);
        void DeleteWhere(Expression<Func<T, bool>> predicate, bool isPhysicalDelete = false);
        void DeleteWhere(List<string> ids, bool isPhysicalDelete = false);
        void DeleteWhere(Expression<Func<T, bool>> predicate);
    }
}
