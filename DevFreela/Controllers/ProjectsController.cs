using DevFreela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly FreeLancerTotalCostConfig _values;
        public ProjectsController(IOptions<FreeLancerTotalCostConfig> options)
        {
            _values = options.Value;
        }

        [HttpPost("{ProjectModel}")]
    
        public IActionResult PostProject(CreateProjectInputModel Model)
        {
            return CreatedAtAction(nameof(GetById), new { Id=1});
        }

        [HttpGet]
        public IActionResult GetSearch(string search)
        {
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task <IActionResult> GetById()
        {
            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, UpdateProjectInputModel Model)
        {

            Model.IdProject = Id;

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task <IActionResult> Delete(int Id)
        {
            return Ok();
        }

        [HttpPut("{Id}/start")]
        public async Task <IActionResult> Start(int Id)
        {
            return NoContent();
        }

        [HttpPut("{Id}/complete")]
        public async Task<IActionResult> Complete(int Id)
        {
            return NoContent();
        }



        [HttpPost("coments/{Id}")]
        public async Task<IActionResult> PostComment(int Id, CreateCommentInputModel Model)
        {
            return Ok();
        }   
    }
}
