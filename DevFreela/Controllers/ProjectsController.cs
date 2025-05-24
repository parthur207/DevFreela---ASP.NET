using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevFreela.Domain.Models;
namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly  IProjectInterface _projectService;

        public ProjectsController(IProjectInterface ProjectService)
        {
            _projectService = ProjectService;
        }

        [HttpPost]
        public async Task<IActionResult> PostProject(CreateProjectModel Model)
        {
            var response = await _projectService.InsertProject(Model);
            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return CreatedAtAction(nameof(GetById), new { Id=1}, Model);
        }

        [HttpGet("get/search")]
        public async Task<IActionResult> GetSearch([FromQuery] string search ="", [FromQuery] int size=3)
        {

            var response= await _projectService.GetSearch(search, size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("get/{idProject}")]
        public  async Task<IActionResult> GetById([FromQuery] int idProject)
        {
            var response= await _projectService.GetById(idProject);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put(int id, UpdateProjectModel Model)
        {
            var response = await _projectService.Update(id, Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
          var response = await _projectService.Delete(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("start/{id}")]
        public async Task <IActionResult> Start([FromRoute] int id)
        {
            var response= await _projectService.Start(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete([FromRoute]int id)
        {

            var response= await _projectService.Complete(id);

            if (response.Status is false)
            {
                return BadRequest();
            }

            return Ok(response);
        }


        [HttpPost("coments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentModel Model)
        {
            var response= await _projectService.InsertComment(Model.IdProject, Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }   
    }
}
