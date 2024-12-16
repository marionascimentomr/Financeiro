using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Moldes;
using Pay.Infra.Data.Contexts;

namespace Pay.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User, Guid>, IUserRepository
    {
        private readonly DataContext? _dataContext;
        public UserRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
