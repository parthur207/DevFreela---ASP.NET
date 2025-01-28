using DevFreela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace DevFreela.Controllers
{

    [ApiController]
    [Route("api/skills")]
    public class SkillsController : ControllerBase
    {
       [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateSkillInputModel model)
        {
            return Created();
        }
    }
}
