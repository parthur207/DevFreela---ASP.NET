using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
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

        private readonly ISkillGenericInterface _skillGenericService;

        public SkillsGenericController(ISkillGenericInterface skillGenericService)
        {
            _skillGenericService = skillGenericService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllSkills()
        {
            var response = await _skillGenericService.GetAllSkills();

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

        [HttpPost("create")]
        public async Task<IActionResult> PostSkill([FromBody] CreateSkillModel Model) 
        {
            var response = await _skillGenericService.CreateSkill(Model);

            if (response.Status is  ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
