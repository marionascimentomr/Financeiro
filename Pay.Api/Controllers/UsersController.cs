using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pay.Application.Dtos.Requests;
using Pay.Application.Interfaces;

namespace Pay.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create([FromBody] UserAddRequestDto dto)
        {
            return StatusCode(201, _userAppService.Create(dto));
        }

        [HttpPut]
        public IActionResult Update(Guid id, UserUpdateRequestDto dto)
        {
            return StatusCode(201, _userAppService.Update(id, dto));
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {
            return StatusCode(201, _userAppService.Get(id));
        }
    }
}
