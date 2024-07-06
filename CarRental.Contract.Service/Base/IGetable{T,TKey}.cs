using CarRental.Contract.Repository.Models;

namespace CarRental.Contract.Service.Base
{
    public interface IGetable<T, in TKey> where T : class, new()
    {
        ICollection<T> GetAllAsync();
        ICollection<T> GetAllAnotherAsync();
        ICollection<T> GetAllByAnotherKeyAsync(string str);
        T GetByKeyIdAsync(TKey keyId);
        T GetByStrAsync(string str);
    }
}
