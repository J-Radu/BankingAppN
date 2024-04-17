using BankingAppN.Database.Interfaces;
using BankingAppN.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppN.Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileManagerController(IProfileService profileService) : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var client = await profileService.GetClientProfileAsync(id);
            return Ok(client);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] Client profileData)
        {
            if (!ModelState.IsValid || id != profileData.ClientId)
            {
                return BadRequest(ModelState);
            }

            var updatedClient = await profileService.UpdateClientProfileAsync(
                id,
                profileData.Name,
                profileData.Surname,
                profileData.Email,
                profileData.Phone,
                profileData.Age
            );

            return Ok(updatedClient);
        }
        
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateProfile(int id, [FromBody] Client profileData)
        {
            if (!ModelState.IsValid || id != profileData.ClientId)
            {
                return BadRequest(ModelState);
            }

            var createdClient = await profileService.CreateFullClientProfileAsync(
                id,
                profileData.Name,
                profileData.Surname,
                profileData.Email,
                profileData.Phone,
                profileData.Age
            );

            return Ok(createdClient);
        }
        [HttpPost("{id}/clone")]
        public async Task<IActionResult> CloneProfile(int id)
        {
            var clonedClient = await profileService.CloneClientProfileAsync(id);

            return Ok(clonedClient);
        }
    }

}