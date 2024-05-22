using BankingApp.Interfaces;
using BankingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileManagerController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileManagerController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var client = await _profileService.GetClientProfileAsync(id);
            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] Client profileData)
        {
            if (!ModelState.IsValid || id != profileData.ClientID)
            {
                return BadRequest(ModelState);
            }

            var updatedClient = await _profileService.UpdateClientProfileAsync(
                id,
                profileData.Name,
                profileData.Surname,
                profileData.Email,
                profileData.Phone,
                profileData.Age
            );

            if (updatedClient == null)
            {
                return NotFound();
            }

            return Ok(updatedClient);
        }
        
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateProfile(int id, [FromBody] Client profileData)
        {
            if (!ModelState.IsValid || id != profileData.ClientID)
            {
                return BadRequest(ModelState);
            }

            var createdClient = await _profileService.CreateFullClientProfileAsync(
                id,
                profileData.Name,
                profileData.Surname,
                profileData.Email,
                profileData.Phone,
                profileData.Age
            );

            if (createdClient == null)
            {
                return NotFound();
            }

            return Ok(createdClient);
        }
        [HttpPost("{id}/clone")]
        public async Task<IActionResult> CloneProfile(int id)
        {
            var clonedClient = await _profileService.CloneClientProfileAsync(id);
            if (clonedClient == null)
            {
                return NotFound();
            }

            return Ok(clonedClient);
        }
    }

}