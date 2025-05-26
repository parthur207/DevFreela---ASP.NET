using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {

        private readonly ISkillInterface _skillInterface;
            
        public SkillsController(ISkillInterface skillInterface)
        {
            _skillInterface = skillInterface;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GettAllSkills()
        {
            var response = await _skillInterface.GetAllSkillsAsync();

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostSkill(CreateSkillModel Model)
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
