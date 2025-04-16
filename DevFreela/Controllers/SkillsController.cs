using DevFreela.Entities;
using DevFreela.Models;
using DevFreela.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DevFreela.Controllers
{

    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {

        private readonly DevFreelaDbContext _dbContexInMemory;

        public SkillsController(DevFreelaDbContext _DbContext)
        {
            _dbContexInMemory = _DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {

            List<SkillModel> SkillsList = new List<SkillModel>();

            var Skills = _dbContexInMemory.Skills.ToList();

            foreach (var skill in Skills)
            {
                var SkillModel=skill.ToSkillModel(skill);
                 SkillsList.Add(SkillModel);
            }

            return Ok(SkillsList);
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
