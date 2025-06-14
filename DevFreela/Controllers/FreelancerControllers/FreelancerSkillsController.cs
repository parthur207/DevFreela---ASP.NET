using DevFreela.Application.Models;
using DevFreela.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers.FreelancerControllers
{
    [Route("api/freelancer/skills")]
    [ApiController]
    [Authorize(Roles = nameof(RolesTypesEnum.FreeLancer))]
    public class FreelancerSkillsController : ControllerBase
    {
       
        [HttpPatch("bind")]
        public async Task<IActionResult> PostUserSkill([FromBody] CreateUserSkillModel Model)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _skillInterface.UpdateSkillAsync(Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
