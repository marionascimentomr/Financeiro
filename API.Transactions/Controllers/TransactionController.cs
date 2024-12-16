using API.Transactions.Application.Interfaces;
using API.Transactions.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Transactions.Controllers
{

    [ApiController]
    [Route("api/transaction")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost("simulate")]
        public IActionResult SimulateTransaction([FromBody] TransactionRequest request)
        {
            var response = _transactionService.SimularTransacao(request);

            if (response.Status == "NAO_APROVADO")
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
