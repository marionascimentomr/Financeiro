using API.Transactions.Dtos;

namespace API.Transactions.Application.Interfaces
{
    public interface ITransactionService
    {
        TransactionResponse SimularTransacao(TransactionRequest request);
    }
}
