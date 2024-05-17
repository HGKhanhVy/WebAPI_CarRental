namespace CarRental.Contract.Service.Base
{
    public interface IDeleteable<in TKey, in T2Key>
    {
        Task DeleteAsync(TKey id, T2Key isPhysical, CancellationToken cancellationToken = default);
        Task DeleteByAnotherKeyAsync(string idAnother, T2Key isPhysical, CancellationToken cancellationToken = default);
    }
}
