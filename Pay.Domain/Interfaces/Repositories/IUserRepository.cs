using Pay.Domain.Moldes;

namespace Pay.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, Guid>
    {
    }
}
