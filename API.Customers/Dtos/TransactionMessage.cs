namespace API.Customers.Dtos
{
    public class TransactionMessage
    {
        public Guid CustomerId { get; set; }
        public decimal Value { get; set; }
    }
}
