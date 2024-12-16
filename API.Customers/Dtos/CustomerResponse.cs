namespace API.Customers.Dtos
{
    public class CustomerResponse
    {
        public string CustomerId { get; set; }
        public string Status { get; set; }
    }


    public class ApiResponse<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public string DetalheErro { get; set; }

        public static ApiResponse<T> Sucesso(T data)
        {
            return new ApiResponse<T>
            {
                Status = "OK",
                Data = data,
                DetalheErro = null
            };
        }

        public static ApiResponse<T> Erro(string detalheErro)
        {
            return new ApiResponse<T>
            {
                Status = "ERRO",
                Data = default,
                DetalheErro = detalheErro
            };
        }
    }
}
