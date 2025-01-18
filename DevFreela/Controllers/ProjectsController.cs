using DevFreela.Models;
using DevFreela.Services.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly  IProjects _projectService;


        public ProjectsController(IProjects ProjectService)
        {
            _projectService = ProjectService;
        }

        [HttpPost("{ProjectModel}")]
        public IActionResult PostProject(CreateProjectInputModel Model)
        {

            //var Response = _projectService.PostProject(Model);
            return CreatedAtAction(nameof(GetById), new { Id=1});
        }

        [HttpGet]
        public IActionResult GetSearch(string search)
        {
            _projectService.GetSearch(search);
            return Ok(search);
        }

        [HttpGet("{Id}")]
        public async Task <IActionResult> GetById(int Id)
        {

            var resposta= await _projectService.GetById(Id);
            return Ok(resposta.Content);
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
            return Created();
        }   
    }
}
