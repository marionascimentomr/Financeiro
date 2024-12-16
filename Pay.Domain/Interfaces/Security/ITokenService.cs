using Pay.Domain.ValueObjects;

namespace Pay.Domain.Interfaces.Security
{
    public interface ITokenService
    {
        string CreateToken(UserAuthV0 userAuthV0);
    }
}
