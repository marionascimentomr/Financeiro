namespace API.Transactions.Dtos
{
    public class TransactionResponse
    {
        public string Status { get; set; } // "APROVADO" ou "NAO_APROVADO"
        public string NumeroTransacao { get; set; } // GUID se aprovado
        public string DetalheErro { get; set; } // Mensagem em caso de erro
    }
}
