using Pay.Domain.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer, Guid>
    {
    }
}
