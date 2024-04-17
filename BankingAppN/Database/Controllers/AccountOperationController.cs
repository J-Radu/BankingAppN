using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppN.Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountOperationController(IAccountOperation service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await service.GetAllAccountOperationsAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var accountOperation = await service.GetAccountOperationByIdAsync(id);
            return Ok(accountOperation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountOperation? accountOperation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdAccountOperation = await service.AddAccountOperationAsync(accountOperation);
            return CreatedAtAction(nameof(GetById), new { id = createdAccountOperation.OperationId }, createdAccountOperation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AccountOperation accountOperation)
        {
            if (!ModelState.IsValid || id != accountOperation.OperationId)
                return BadRequest();
            await service.UpdateAccountOperationAsync(accountOperation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAccountOperationAsync(id);
            return NoContent();
        }
    }
}