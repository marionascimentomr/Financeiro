using API.Transactions.Application.Interfaces;
using API.Transactions.Dtos;
using API.Transactions.Message;
using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Moldes;

namespace API.Transactions.Application
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RabbitMqProducerService _rabbitMqProducerService;

        public TransactionService(IUnitOfWork unitOfWork, RabbitMqProducerService rabbitMqProducerService)
        {
            _unitOfWork = unitOfWork;
            _rabbitMqProducerService = rabbitMqProducerService;

        }

        public TransactionResponse SimularTransacao(TransactionRequest request)
        {
            var cliente = _unitOfWork.CustomerRepository.GetById(request.CustomerId);
            if (cliente == null)
            {
                return new TransactionResponse
                {
                    Status = "NAO_APROVADO",
                    NumeroTransacao = null,
                    DetalheErro = "Cliente não encontrado."
                };
            }

            if (request.ValorTransacao > cliente.ValorLimite)
            {
                return new TransactionResponse
                {
                    Status = "NAO_APROVADO",
                    NumeroTransacao = null,
                    DetalheErro = "Valor da transação excede o limite do cliente."
                };
            }

            var numeroTransacao = Guid.NewGuid().ToString();

            var message = new
            {
                CustomerId = request.CustomerId,
                Value = request.ValorTransacao
            };

            _rabbitMqProducerService.SendMessage(message);

            // Retornar sucesso
            return new TransactionResponse
            {
                Status = "APROVADO",
                NumeroTransacao = numeroTransacao,
                DetalheErro = null
            };
        }
    }

}
