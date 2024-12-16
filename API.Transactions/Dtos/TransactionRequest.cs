namespace API.Transactions.Dtos
{
    public class TransactionRequest
    {
        public Guid CustomerId { get; set; }
        public decimal ValorTransacao { get; set; }
    }
}
