using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Application.Interfaces.FreeLancerInterface;
using DevFreela.Application.Services;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.Updates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers.FreelancerControllers
{
    [Route("api/freelancer")]
    [ApiController]
    [Authorize(Roles = nameof(RolesTypesEnum.FreeLancer))]
    public class FreelancerProjectsController : ControllerBase
    {

        private readonly IFreelancerProjectInterface _freelancerProjectService;

        public FreelancerProjectsController(IFreelancerProjectInterface freelancerProjectService)
        {
            _freelancerProjectService = freelancerProjectService;
        }


        [HttpGet("myProjects/search")]
        public async Task<IActionResult> GetMyProjectByNameOrDescription([FromQuery] string NameOrDescription, [FromQuery] int size = 3)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Response = await _freelancerProjectService.GetAllMyProjectsByNameOrDescription(userId, NameOrDescription, size);
             
            if (Response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(Response);
            }

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }

        [HttpGet("myProjects/status")]
        public async Task<IActionResult> GetAllMyProjectsByStatus([FromQuery] ProjectStatusEnum status, [FromQuery] int size = 3)
        {
            int UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _freelancerProjectService.GetAllMyProjectsByStatus(UserId,status, size);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("project/create")]
        public async Task<IActionResult> PostProject([FromBody] CreateProjectModel Model)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _freelancerProjectService.CreateProject(userId, Model);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("project/update/{idProject}")]
        public async Task<IActionResult> PutProject([FromRoute] int idProject, [FromBody] UpdateProjectModel Model)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _freelancerProjectService.UpdateProject(idProject, userId, Model);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPatch("project/start/{idProject}")]
        public async Task<IActionResult> StartProject([FromRoute] int idProject)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _freelancerProjectService.StartProject(idProject, userId);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPatch("project/suspend/{idProject}")]
        public async Task<IActionResult> SuspendProject([FromRoute] int idProject)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _freelancerProjectService.SuspendProject(idProject, userId);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPatch("project/available/{idProject}")]
        public async Task<IActionResult> AvailableProject([FromRoute] int idProject)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var response = await _freelancerProjectService.MakeProjectAvailable(idProject, userId);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("project/delete/{idProject}")]
        public async Task<IActionResult> DeleteProject([FromRoute] int idProject)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _freelancerProjectService.DeleteProject(idProject, userId);

            if (response.Status is ResponseStatusEnum.NotFound)
            {
                return NotFound(response);
            }

            if (response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
