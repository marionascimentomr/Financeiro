namespace API.Customers.Dtos
{
    public class CustomerRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public decimal ValorLimite { get; set; }
    }
}
