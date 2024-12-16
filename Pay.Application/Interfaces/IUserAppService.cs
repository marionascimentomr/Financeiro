using Pay.Application.Dtos.Requests;
using Pay.Application.Dtos.Responses;

namespace Pay.Application.Interfaces
{
    public interface IUserAppService : IDisposable
    {
        UserResponseDto Create(UserAddRequestDto dto);
        UserResponseDto Update(Guid id, UserUpdateRequestDto dto);
        UserResponseDto Get(Guid id);
    }
}
