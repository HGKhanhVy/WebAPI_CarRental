namespace CarRental.Contract.Service.Base
{
    public interface ICounteable<in T, TKey> where T : class, new()
    {
        Task<int> CountAsync();
    }
}