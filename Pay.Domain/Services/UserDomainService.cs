using Pay.Domain.Exceptions;
using Pay.Domain.Interfaces.Repositories;
using Pay.Domain.Interfaces.Security;
using Pay.Domain.Interfaces.Services;
using Pay.Domain.Moldes;
using Pay.Domain.ValueObjects;

namespace Pay.Domain.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        public UserDomainService(IUnitOfWork unitOfWork, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
        }

        public void Create(User user)
        {
            if (Get(user.Email) != null)
                throw new EmailAlreadyExistsExcption(user.Email);

            _unitOfWork?.UserRepository.Add(user);
            _unitOfWork?.SaveChanges();            
        }

        public void Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.SaveChanges();
        }

        public User? Get(Guid id)
        {
            return _unitOfWork?.UserRepository.GetById(id);
        }

        public User? Get(string email)
        {
            return _unitOfWork.UserRepository.Get
            (u => u.Email.Equals(email));

        }

        public User? Get(string email, string password)
        {
            return _unitOfWork.UserRepository.Get
            (u => u.Email.Equals(email) && u.Password.Equals(password));

        }

        public string Authenticate(string email, string password)
        {
            var user = Get(email, password);

            if (user == null)
                throw new AccessDeniedException();

            var userAuth = new UserAuthV0
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = "USER_ROLE",
                SignedAt = DateTime.Now,
            };
            return _tokenService.CreateToken(userAuth);
        }

        public void Dispose()
        {
            _unitOfWork?.UserRepository.Dispose();
        }
    }
}
