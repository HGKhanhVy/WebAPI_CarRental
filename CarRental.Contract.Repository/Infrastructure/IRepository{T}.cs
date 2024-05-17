using CarRental.Contract.Repository.IBase;
using CarRental.Contract.Repository.Models;

namespace CarRental.Contract.Repository.Infrastructure
{
    public interface IRepository<T> : IBaseRepository<T> where T : Entity, new()
    {
    }
}
