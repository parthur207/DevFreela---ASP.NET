using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers.GenericControllers
{
    [Route("api/generic/project")]
    [ApiController]
    
    public class ProjectsGenericController : ControllerBase
    {

        private readonly IProjectGenericInterface _projectGenericService;

        public ProjectsGenericController(IProjectGenericInterface projectGenericService)
        {
            _projectGenericService = projectGenericService;
        }

        [AllowAnonymous]
        [HttpGet("get/search")]
        public async Task<IActionResult> GetSearch([FromQuery] string search = "", [FromQuery] int size = 3)
        {

            var response = await _projectGenericService.GetAllProjects(search, size);

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


        [AllowAnonymous]
        [HttpGet("getByOwner")]
        public async Task<IActionResult> GetByOwner([FromQuery] string NameOrEmail, [FromQuery] int size = 3)
        {
            var response = await _projectGenericService.GetAllProjectsByOwner(NameOrEmail, size);

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

        [Authorize(Roles = $"{nameof(RolesTypesEnum.Client)},{nameof(RolesTypesEnum.FreeLancer)}")]
        [HttpPost("createComment")]
        public async Task<IActionResult> PostCommentProject([FromBody] CreateCommentModel model)
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var response = await _projectGenericService.CreateCommentProject(userId, model);

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
