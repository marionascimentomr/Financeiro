using API.Customers.Application.Interfaces;
using API.Customers.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pay.Domain.Moldes;
using System;

namespace API.Customers.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }

        [HttpPost("register")]
        public ApiResponse<CustomerResponse> Register(CustomerRequest request)
        {
            return _service.Create(request);

        }

        [HttpGet("list")]
        public IActionResult GetAll()
        {
            var Customers = _service.GetAll();
            return Ok(Customers);
        }
    }
}
