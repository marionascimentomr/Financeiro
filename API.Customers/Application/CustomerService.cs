using API.Customers.Application.Interfaces;
using API.Customers.Dtos;
using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Moldes;
using Pay.Infra.Data.Repositories;

namespace API.Customers.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDomainService _domainService;
        private readonly ICacheService _cacheService;
        private const string CacheKey = "Customers";
        private readonly IUnitOfWork _unitOfWork;

        public CustomerService(ICustomerDomainService domainService, ICacheService cacheService, IUnitOfWork unitOfWork)
        {
            _domainService = domainService;
            _cacheService = cacheService;
            _unitOfWork = unitOfWork;
        }

        public ApiResponse<CustomerResponse> Create(CustomerRequest request)
        {
            if (_domainService.Get(request.CPF) != null)
            {
                return ApiResponse<CustomerResponse>.Erro($"O CPF {request.CPF} já está cadastrado.");
            }

            if (request.ValorLimite < 0)
            {
                return ApiResponse<CustomerResponse>.Erro("O valor do limite não pode ser negativo.");
            }

            var client = new Customer
            {
                Nome = request.Nome,
                CPF = request.CPF,
                ValorLimite = request.ValorLimite
            };

            _domainService.Create(client);
            _cacheService.Set(CacheKey, _unitOfWork.CustomerRepository.GetAll(), TimeSpan.FromMinutes(10));

            return ApiResponse<CustomerResponse>.Sucesso(new CustomerResponse
            {
                CustomerId = client.Id.ToString(),
                Status = "Sucess"
            });
        }


        public List<Customer> GetAll()
        {
            var cachedClients = _cacheService.Get<List<Customer>>(CacheKey);
            if (cachedClients != null)
                return cachedClients;

            var clients = _domainService.GetAll();
            _cacheService.Set(CacheKey, clients, TimeSpan.FromMinutes(10));
            return clients;
        }
    }
}
