using Pay.Application.Dtos.Requests;
using Pay.Application.Dtos.Responses;

namespace Pay.Application.Interfaces
{
    public interface IAuthAppService : IDisposable
    {
        LoginResponseDto Login(LoginRequestDto dto);
        void Register(UserAddRequestDto dto);
    }
}
