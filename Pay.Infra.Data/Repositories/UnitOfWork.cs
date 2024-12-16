using Pay.Domain.Interfaces.Repositories;
using Pay.Infra.Data.Contexts;

namespace Pay.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext? _dataContext;
        public UnitOfWork(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }


        public IUserRepository UserRepository => new UserRepository(_dataContext);

        public ICustomerRepository CustomerRepository => new CustomerRepository(_dataContext);

        public void SaveChanges()
        {
            _dataContext?.SaveChanges();
        }
        public Task SaveChangesAsync()
        {
            _dataContext?.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _dataContext?.Dispose();
        }
    }
}
