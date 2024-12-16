using API.Customers.Dtos;
using Pay.Domain.Moldes;

namespace API.Customers.Application.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAll();
        ApiResponse<CustomerResponse> Create(CustomerRequest customer);
    }
}
