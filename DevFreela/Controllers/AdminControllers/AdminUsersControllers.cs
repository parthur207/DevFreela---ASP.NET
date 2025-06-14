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

        private readonly IAdminUsersInterface _adminUserService;

        public AdminUsersControllers(IAdminUsersInterface adminUserService)
        {
            _adminUserService = adminUserService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers([FromQuery] int Size=5)
        {
            
            var Response= await _adminUserService.GetAllUsersAdmin(Size);

            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }


        [HttpGet("all/incactive")]
        public async Task<IActionResult> GetAllUsersInactive([FromQuery] int Size = 5)
        {

            var Response = await _adminUserService.GetAllUsersInactiveAdmin(Size);

            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }


        [HttpGet("email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email)
        {
            var Response = await _adminUserService.GetUserByEmailAdmin(email);

            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }

        [HttpGet("freelancers")]
        public async Task<IActionResult> GetAllFreelancers([FromQuery] int Size=5)
        {
            var Response= await _adminUserService.GetAllFreelancersAdmin(Size);

            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }

        [HttpGet("clients")]
        public async Task<IActionResult> GetAllClients([FromQuery] int Size = 5)
        {

            var Response = await _adminUserService.GetAllClientsAdmin(Size);

            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }

        [HttpDelete("inactive")]
        public async Task<IActionResult> InactiveUser([FromQuery] string Email)
        {
            var Response = await _adminUserService.InactiveUserAdmin(Email);

            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }

        [HttpPut("active")]
        public async Task<IActionResult> ActiveUser([FromQuery] string Email)
        {

            var Response= await _adminUserService.ActivateUserAdmin(Email);

            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }
    }
}
