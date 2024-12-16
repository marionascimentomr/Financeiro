using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pay.Application.Dtos.Requests;
using Pay.Application.Dtos.Responses;
using Pay.Application.Interfaces;

namespace Pay.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthAppService? _authAppService;
        public AuthController(IAuthAppService? authAppService)
        {
            _authAppService = authAppService;
        }

        [AllowAnonymous]
        [Route("login")]
        [HttpPost]
        [ProducesResponseType(typeof(LoginResponseDto), 200)]
        public IActionResult Login(LoginRequestDto dto)
        {
            return StatusCode(200, _authAppService?.Login(dto));
        }
    }
}
