namespace Pay.Domain.Exceptions
{
    public class EmailAlreadyExistsExcption : Exception
    {
        public EmailAlreadyExistsExcption(string cpf)
            : base($"O cpf informado '{cpf}' já está cadastrado. Tente outro.")
        {
        }
    }
}
    

