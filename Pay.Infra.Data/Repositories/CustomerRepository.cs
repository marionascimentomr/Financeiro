using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Moldes;
using Pay.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay.Infra.Data.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, Guid>, ICustomerRepository
    {
        private readonly DataContext? _dataContext;
        public CustomerRepository(DataContext? dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }
    }
    
}
