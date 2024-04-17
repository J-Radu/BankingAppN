using BankingAppN.Database.DTO;
using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppN.Database.Controllers
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
            return Ok(account);
        }
        
        [HttpGet("dto{id}")]
        public async Task<IActionResult> GetByIdDto(int id)
        {
            var account = await service.GetAllAccountAsDtoAsync();
            return Ok(account);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Account? account)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdAccount = await service.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetById), new { id = createdAccount.AccountId }, createdAccount);
        }
        
        [HttpPost("dto")]
        public async Task<IActionResult> CreateDto([FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var account = new Account
            {
                AccountId = accountDto.AccountId,
                ClientId = accountDto.ClientId,
                AccountType = accountDto.AccountType,
                AccountNumber = accountDto.AccountNumber,
                Balance = accountDto.Balance,
                OpenDate = accountDto.OpenDate,
            };
            var createdAccount = await service.AddAccountAsync(account);
            return CreatedAtAction(nameof(GetByIdDto), new { id = createdAccount.AccountId }, createdAccount);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Account account)
        {
            if (!ModelState.IsValid || id != account.AccountId)
                return BadRequest();
            await service.UpdateAccountAsync(account);
            return NoContent();
        }
        [HttpPut("dto/{id}")]
        public async Task<IActionResult> UpdateDto(int id, [FromBody] AccountDto accountDto)
        {
            if (!ModelState.IsValid || id != accountDto.AccountId)
                return BadRequest();
            var account = new Account
            {
                AccountId = accountDto.AccountId,
                ClientId = accountDto.ClientId,
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