using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Application.Services;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers
{
    [Route("api/freelancer")]
    [ApiController]
    [Authorize(Roles = nameof(RolesTypesEnum.FreeLancer))]
    public class FreelancerProjectsController : ControllerBase
    {
        //private readonly 


        [HttpGet("myProjects/search")]
        public async Task<IActionResult> GetAllMyProjects([FromQuery] string search = "", [FromQuery] int size = 3)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _projectService.GetSearchAsync(search, size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("MyProject/{idProject}")]
        public async Task<IActionResult> GetMyProjectById([FromRoute] int idProject)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _projectService.GetByIdAsync(idProject);
             
            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("myProjects/status")]
        public async Task<IActionResult> GetAllMyProjectsByStatus([FromQuery] string search = "", [FromQuery] ProjectStatusEnum ?status=null, [FromQuery] int size = 3)
        {
            int UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _projectService.GetSearchAsync(search, size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpPost("project/create")]
        public async Task<IActionResult> PostProject([FromBody] CreateProjectModel Model)
        {
            var response = await _projectService.CreateProjectAsync(Model);
            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("project/update/{id}")]
        public async Task<IActionResult> PutProject([FromRoute] int id, [FromBody] UpdateProjectModel Model)
        {
            var response = await _projectService.UpdateAsync(id, Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("project/delete/{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int id)
        {
            var response = await _projectService.DeleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("project/start/{id}")]
        public async Task<IActionResult> StartProject([FromRoute] int id)
        {
            var response = await _projectService.StartAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("project/complete/{id}")]
        public async Task<IActionResult> CompleteProject([FromRoute] int id)
        {

            var response = await _projectService.CompleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("project/cancel/{id}")]
        public async Task<IActionResult> CancelProject([FromRoute] int id)
        {

            var response = await _projectService.CompleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("project/suspend/{id}")]
        public async Task<IActionResult> SuspendProject([FromRoute] int id)
        {

            var response = await _projectService.CompleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("project/available/{id}")]
        public async Task<IActionResult> AvailableProject([FromRoute] int id)
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
