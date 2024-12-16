using Pay.Application.Dtos.Requests;
using Pay.Application.Dtos.Responses;
using Pay.Application.Interfaces;
using Pay.Domain.Exceptions;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Moldes;

namespace Pay.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IUserDomainService _userDomainService;

        public AuthAppService(IUserDomainService userDomainService)
        {
            _userDomainService = userDomainService;
        }

        public LoginResponseDto Login(LoginRequestDto dto)
        {
            try
            {
                var accessToken = _userDomainService.Authenticate(dto.Email, dto.Password);

                return new LoginResponseDto
                {
                    AccessToken = accessToken
                };
            }
            catch (AccessDeniedException e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public void Register(UserAddRequestDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = DateTime.UtcNow
            };

            _userDomainService.Create(user);
        }

        public void Dispose()
        {
            _userDomainService.Dispose();
        }
    }
}
