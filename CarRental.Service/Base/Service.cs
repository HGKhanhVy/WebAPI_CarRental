using Microsoft.Extensions.DependencyInjection;
using CarRental.Contract.Repository.Infrastructure;

namespace CarRental.Service.Base
{
    public abstract class Service
    {
        protected readonly IUnitOfWork UnitOfWork;
        protected Service(IServiceProvider serviceProvider)
        {
            UnitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }
    }
}
