using Pay.Domain.Moldes;

namespace Pay.Domain.Interfaces.Services
{
    public interface IUserDomainService : IDisposable
    {
        void Create(User user);
        void Update(User user);
        User? Get(Guid id);
        User? Get(string email);
        string Authenticate(string email, string password);
    }
}
