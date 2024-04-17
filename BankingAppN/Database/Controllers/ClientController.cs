using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppN.Database.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ClientController(IClient service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await service.GetAllClientsAsync();
            return Ok(clients);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await service.GetClientByIdAsync(id);
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client? client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdClient = await service.AddClientAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = createdClient.ClientId }, createdClient);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid || id != client.ClientId)
                return BadRequest();
            await service.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteClientAsync(id);
            return NoContent();
        }
    }
}