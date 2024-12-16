using Pay.Domain.Exceptions;
using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Moldes;

namespace Pay.Domain.Services
{
    public class CustomerDomainService : ICustomerDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Customer customer)
        {
            if (customer.ValorLimite < 0)
                throw new InvalidOperationException("O valor do limite não pode ser negativo.");

            if (Get(customer.CPF) != null)
                throw new EmailAlreadyExistsExcption(customer.CPF);

            _unitOfWork?.CustomerRepository.Add(customer);
            _unitOfWork?.SaveChanges();
        }

        public Customer? Get(string cpf)
        {
            return _unitOfWork.CustomerRepository.Get
            (u => u.CPF.Equals(cpf));
        }

        public List<Customer> GetAll()
        {
            return _unitOfWork.CustomerRepository.GetAll();
        }

        public async Task UpdateCustomerLimitAsync(Guid customerId, decimal transactionValue)
        {
            // Buscar o cliente pelo ID de forma assíncrona
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(customerId);

            // Verificar se o cliente existe
            if (customer == null)
            {
                Console.WriteLine($"Customer with ID {customerId} not found.");
                return;
            }

            // Verificar se o valor da transação é maior que o limite atual
            if (transactionValue > customer.ValorLimite)
            {
                Console.WriteLine($"Transaction value exceeds the customer's limit. Transaction not authorized.");
                return;
            }

            // Subtrair o valor da transação do limite
            customer.ValorLimite -= transactionValue;

            await _unitOfWork.CustomerRepository.UpdateAsync(customer);
            // Salvar alterações no banco de dados de forma assíncrona
            await _unitOfWork.SaveChangesAsync();

            Console.WriteLine($"Updated customer {customerId} with new limit after transaction of {transactionValue}.");
        }


        public void Dispose()
        {
            _unitOfWork?.UserRepository.Dispose();
        }
    }
}
