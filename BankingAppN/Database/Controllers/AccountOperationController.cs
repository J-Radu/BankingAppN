using BankingApp.Interfaces;
using BankingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountOperationController : ControllerBase
    {
        private readonly IAccountOperation _service;

        public AccountOperationController(IAccountOperation service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _service.GetAllAccountOperationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var accountOperation = await _service.GetAccountOperationByIdAsync(id);
            if (accountOperation == null)
                return NotFound();
            return Ok(accountOperation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountOperation accountOperation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdAccountOperation = await _service.AddAccountOperationAsync(accountOperation);
            return CreatedAtAction(nameof(GetById), new { id = createdAccountOperation.OperationID }, createdAccountOperation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AccountOperation accountOperation)
        {
            if (!ModelState.IsValid || id != accountOperation.OperationID)
                return BadRequest();
            await _service.UpdateAccountOperationAsync(accountOperation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAccountOperationAsync(id);
            return NoContent();
        }
    }
}