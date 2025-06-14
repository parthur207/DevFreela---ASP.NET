using DevFreela.Application.Interfaces.FreeLancerInterface;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
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
       
        private readonly IFreelancerUserSkillInterface _freelancerUserSkillService;

        public FreelancerSkillsController(IFreelancerUserSkillInterface freelancerUserSkillService)
        {
            _freelancerUserSkillService = freelancerUserSkillService;
        }

        [HttpPatch("bind")]
        public async Task<IActionResult> PostUserSkill([FromBody] CreateUserSkillModel Model)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _freelancerUserSkillService.CreateUserSkill(userId, Model);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
