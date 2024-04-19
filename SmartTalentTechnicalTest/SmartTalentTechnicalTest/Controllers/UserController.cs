using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartTalentTechnicalTest.ApplicationServices;
using SmartTalentTechnicalTest.Commands;
using System.Security.Claims;

namespace SmartTalentTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userServices;
        public UserController(UserServices userServices) { 

            this._userServices = userServices;
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(CreateUserCommand createUserCommand)
        {
            await _userServices.HandleCommand(createUserCommand);
            return Ok(createUserCommand);
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult>GetUser(Guid id)
        {
            var response = await _userServices.GetUser(id);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, UpdateUserCommand updateUserCommand)
        {
            if (id != updateUserCommand.userId)
            {
                return BadRequest();
            }

            await _userServices.HandleCommand(updateUserCommand);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _userServices.DeleteUser(id);
            return NoContent();
        }
    }
}
