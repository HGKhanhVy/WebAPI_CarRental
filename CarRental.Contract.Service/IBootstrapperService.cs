namespace CarRental.Contract.Service
{
    public interface IBootstrapperService
    {
        /// <summary>
        ///     Initial Database, Background Services and so on.
        /// </summary>
        Task InitialAsync(CancellationToken cancellationToken = default);
    }
}
