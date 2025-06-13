using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Domain.Enums;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers.AdminControllers
{
    [Route("api/admin/users")]
    [ApiController]
    [Authorize(Roles = nameof(RolesTypesEnum.Admin))]

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
        public async Task<IActionResult> GetAllUsers([FromQuery] int Size=5)
        {
            

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var response = await _userInterface.GetByEmailAsync(email);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("freelancers")]
        public async Task<IActionResult> GetAllFreelancers([FromQuery] int Size=5)
        {

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("clients")]
        public async Task<IActionResult> GetAllClients([FromQuery] int Size = 5)
        {

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }



    }
}
