using CarRental.Contract.Repository.Models;
using CarRental.Core.Models.Login;

namespace CarRental.Contract.Service.Base
{
    public interface IGetable<T, in TKey> where T : class, new()
    {
        ICollection<T> GetAllAsync();
        ICollection<T> GetAllAnotherAsync();
        ICollection<T> GetAllByAnotherKeyAsync(string str);
        T GetByKeyIdAsync(TKey keyId);
        T GetByStrAsync(string str);
        T GetByLoginAsync(LoginModel model);
        UserEntity GetByUserNameAsync(RefreshTokenEntity model);
    }
}
