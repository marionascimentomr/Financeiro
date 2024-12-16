using Pay.Domain.Moldes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pay.Domain.Interfaces.Services
{
    public interface ICustomerDomainService : IDisposable
    {
        void Create(Customer user);
        List<Customer?> GetAll();

        Customer Get(string cpf);
        Task UpdateCustomerLimitAsync(Guid customerId, decimal transactionValue);
    }
}
