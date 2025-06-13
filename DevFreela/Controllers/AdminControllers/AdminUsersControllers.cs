using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace DevFreela.API.Controllers.AdminControllers
{
    [Route("api/admin/users")]
    [ApiController]

    public class AdminUsersControllers : ControllerBase
    {

        private readonly IAdminUserInterface _userInterface;
        private readonly IUserSkillInterface _userSkillInterface;

        public AdminUsersControllers(IAdminUserInterface userInterface, IUserSkillInterface userSkillInterface)
        {
         
            _userInterface = userInterface;
            _userSkillInterface = userSkillInterface;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _userInterface.GetAllUsersAsync();

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpGet("email")]
        public async Task<IActionResult> GetById([FromQuery] string email)
        {
            var response = await _userInterface.GetByEmailAsync(email);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
