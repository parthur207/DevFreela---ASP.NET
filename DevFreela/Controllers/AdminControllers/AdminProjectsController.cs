using DevFreela.Application.Services;
using DevFreela.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DevFreela.API.Controllers.AdminControllers
{
    [Route("api/admin/projects")]
    [ApiController]
    [Authorize(Roles = nameof(RolesTypesEnum.Admin))]
    public class AdminProjectsController : ControllerBase
    {
        /*private readonly ProjectService _projectService;
        public AdminProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }*/

        [HttpGet("get/search")]
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

        [HttpGet("getAll/status")]
        public async Task<IActionResult> GetAllByStatus([FromQuery] ProjectStatusEnum status)
        {
            var response = await _projectService.GetByIdAsync(idProject);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("get/freelancer")]
        public async Task<IActionResult> GetByFreelancer([FromQuery] string EmailFreelancer)
        {
            var response = await _projectService.GetByIdAsync(EmailFreelancer);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("get/client")]
        public async Task<IActionResult> GetByClient([FromQuery] string EmailClient)
        {
            var response = await _projectService.GetByIdAsync(EmailClient);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }



    }
}
