using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{
    [Route("api/freelancer")]
    [ApiController]
    public class FreelancerProjectsController : ControllerBase
    {
        //private readonly 

        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody] CreateProjectModel Model)
        {
            var response = await _projectService.CreateProjectAsync(Model);
            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("project/search")]
        public async Task<IActionResult> GetSearch([FromQuery] string search = "", [FromQuery] int size = 3)
        {

            var response = await _projectService.GetSearchAsync(search, size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("get/{idProject}")]
        public async Task<IActionResult> GetById([FromRoute] int idProject)
        {
            var response = await _projectService.GetByIdAsync(idProject);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] UpdateProjectModel Model)
        {
            var response = await _projectService.UpdateAsync(id, Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var response = await _projectService.DeleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("start/{id}")]
        public async Task<IActionResult> Start([FromRoute] int id)
        {
            var response = await _projectService.StartAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete([FromRoute] int id)
        {

            var response = await _projectService.CompleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
