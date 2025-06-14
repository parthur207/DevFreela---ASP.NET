using DevFreela.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers.GenericControllers
{
    [Route("api/generic/project")]
    [ApiController]
    [AllowAnonymous]
    public class ProjectsGenericController : ControllerBase
    {
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

        [HttpGet("getByOwner")]
        public async Task<IActionResult> GetByOwner([FromQuery] string emailOrName, [FromQuery] int size = 3)
        {
            var response = await _projectService.GetByOwnerAsync(emailOrName, size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

    }
}
