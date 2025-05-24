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
            List<(int,string)> ListSkillsEntity = _dbContexInMemory.Skills
                 .AsEnumerable()
                .Select(x =>(x.Id,x.Description))
                .ToList();


            if (ListSkillsEntity is null)
            {
                return NoContent();
            }

            var SkillsModel = SkillMapper.ToListSkillDTO(ListSkillsEntity);

            return Ok(SkillsModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostSkill(CreateSkillModel Model)
        {
            var entity = Model.ToSkillEntity();

            _dbContexInMemory.Skills.Add(entity);
            _dbContexInMemory.SaveChanges();

            return NoContent();
        }
    }
}
