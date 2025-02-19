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
        public async Task<IActionResult> GetAll()
        {
            var Skills = _dbContexInMemory.Skills.ToList();
            return Ok(Skills);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSkillModel Model)
        {
            var entity = Model.ToSkillModel();

            _dbContexInMemory.Skills.Add(entity);
            _dbContexInMemory.SaveChanges();

            return Created();
        }
    }
}
