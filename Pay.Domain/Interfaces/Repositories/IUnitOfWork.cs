namespace Pay.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}