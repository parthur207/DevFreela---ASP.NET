using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Application.Mappers;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/skills")]
    [Authorize]
    public class SkillsGenericController : ControllerBase
    {

        private readonly IGenericSkillInterface _skillInterface;
            
        public SkillsGenericController(IGenericSkillInterface skillInterface)
        {
            _skillInterface = skillInterface;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSkills()
        {
            var response = await _skillInterface.GetAllSkillsAsync();

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [Authorize(Roles = $"{nameof(RolesTypesEnum.Admin)},{nameof(RolesTypesEnum.FreeLancer)}")]
        [HttpPost]
        public async Task<IActionResult> PostSkill([FromBody] CreateSkillModel Model) 
        {
            var response = await _skillInterface.CreateSkillAsync(Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
