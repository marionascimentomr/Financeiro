using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pay.Application.Dtos.Requests;
using Pay.Application.Dtos.Responses;
using Pay.Application.Interfaces;

namespace API.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService? _authAppService;
        public AuthController(IAuthAppService? authAppService)
        {
            _authAppService = authAppService;
        }

        /// <summary>
        /// Autenticar o usuário
        /// </summary>
        [Route("register")]
        [HttpPost]
        public void Register(UserAddRequestDto dto)
        {
            _authAppService?.Register(dto);
        }

        /// <summary>
        /// Autenticar o usuário
        /// </summary>
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        public IActionResult Login(LoginRequestDto dto)
        {
            return StatusCode(200, _authAppService?.Login(dto));
        }
    }
}
