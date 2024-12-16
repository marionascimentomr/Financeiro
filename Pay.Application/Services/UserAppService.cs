using AutoMapper;
using Pay.Application.Dtos.Requests;
using Pay.Application.Dtos.Responses;
using Pay.Application.Interfaces;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Moldes;

namespace Pay.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService _userDomainService;
        private readonly IMapper _mapper;
        public UserAppService(IUserDomainService userDomainService, IMapper mapper)
        {
            _userDomainService = userDomainService;
            _mapper = mapper;
        }

        public UserResponseDto Create(UserAddRequestDto dto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = DateTime.UtcNow
            };

            _userDomainService.Create(user);
            return _mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Update(Guid id, UserUpdateRequestDto dto)
        {
            var user = _userDomainService.Get(id);

            if (user == null) { return new UserResponseDto(); }

            user.Name = dto.Name;
            _userDomainService.Update(user);

            return _mapper.Map<UserResponseDto>(user);
        }
        public UserResponseDto Get(Guid id)
        {
            var user = _userDomainService.Get(id);

            if (user == null) { return new UserResponseDto(); }

            return _mapper.Map<UserResponseDto>(user);
        }
        public void Dispose()
        {
            _userDomainService.Dispose();
        }
    }
}
