using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.Data;
using System.Security.Claims;

namespace DevFreela.API.Controllers.GenericControllers
{

    [ApiController]
    [Route("api/generic/skills")]
    [Authorize(Roles = $"{nameof(RolesTypesEnum.Admin)},{nameof(RolesTypesEnum.FreeLancer)}")]
    public class SkillsGenericController : ControllerBase
    {

        private readonly ISkillGenericInterface _skillInterface;
            
        public SkillsGenericController(ISkillGenericInterface skillInterface)
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

        [HttpPost("create")]
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
