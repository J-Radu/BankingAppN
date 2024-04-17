using BankingApp.Interfaces;
using BankingApp.Models;
using BankingAppN.Database.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccount service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await service.GetAllAccountsAsync();
            return Ok(accounts);
        }
        [HttpGet("dto")]
        public async Task<IActionResult> GetAllAsDto()
        {
            var accounts = await service.GetAllAccountAsDtoAsync();
            return Ok(accounts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var account = await service.GetAccountByIdAsync(id);
            if (account == null)
                return NotFound();
            return Ok(account);
        }
        
        [HttpGet("dto{id}")]
        public async Task<IActionResult> GetByIdDto(int id)
        {
            var account = await service.GetAllAccountAsDtoAsync();
            if (account == null)
                return NotFound();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdAccount = await service.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = createdAccount.AccountID }, createdAccount);
        }
        
        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var account = new Account
            {
                AccountID = accountDto.AccountID,
                ClientID = accountDto.ClientID,
                AccountType = accountDto.AccountType,
                AccountNumber = accountDto.AccountNumber,
                Balance = accountDto.Balance,
                OpenDate = accountDto.OpenDate,
            };
            var createdAccount = await service.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetByIdDto), new { id = createdAccount.AccountID }, createdAccount);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Account account)
        {
            if (!ModelState.IsValid || id != account.AccountID)
                return BadRequest();
            await service.UpdateAccountAsync(account);
            return NoContent();
        }
        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid || id != accountDto.AccountID)
                return BadRequest();
            var account = new Account
            {
                AccountID = accountDto.AccountID,
                ClientID = accountDto.ClientID,
                AccountType = accountDto.AccountType,
                AccountNumber = accountDto.AccountNumber,
                Balance = accountDto.Balance,
                OpenDate = accountDto.OpenDate,
            };
            await service.UpdateAccountAsync(account);
            return NoContent();
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteAccountAsync(id);
            return NoContent();
        }
    }
}