using BankingApp.Interfaces;
using BankingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ClientController : ControllerBase
    {
        private readonly IClient _service;

        public ClientController(IClient service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Clients = await _service.GetAllClientsAsync();
            return Ok(Clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _service.GetClientByIdAsync(id);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Client client)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var createdClient = await _service.AddClientAsync(client);
            return CreatedAtAction(nameof(GetById), new { id = createdClient.ClientID }, createdClient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Client client)
        {
            if (!ModelState.IsValid || id != client.ClientID)
                return BadRequest();
            await _service.UpdateClientAsync(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteClientAsync(id);
            return NoContent();
        }
    }
}