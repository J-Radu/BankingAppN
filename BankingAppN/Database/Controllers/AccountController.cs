using BankingApp.Interfaces;
using BankingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _service;

        public AccountController(IAccount service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _service.GetAllAccountsAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await _service.GetAccountByIdAsync(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdAccount = await _service.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = createdAccount.AccountID }, createdAccount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Account account)
        {
            if (!ModelState.IsValid || id != account.AccountID)
                return BadRequest();
            await _service.UpdateAccountAsync(account);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAccountAsync(id);
            return NoContent();
        }
    }
}