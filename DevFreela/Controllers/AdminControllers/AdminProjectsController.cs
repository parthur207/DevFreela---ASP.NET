using DevFreela.Application.Interfaces.AdminInterface;
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

        private readonly IAdminProjectsInterface _adminProjectsService;

        public AdminProjectsController(IAdminProjectsInterface adminProjectsService)
        {
            _adminProjectsService = adminProjectsService;
        }

        [HttpGet("get/search")]
        public async Task<IActionResult> GetSearch([FromQuery] string search = "", [FromQuery] int size = 5)
        {

            var response = await _adminProjectsService.GetSearchAdmin(search, size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("getAll/status")]
        public async Task<IActionResult> GetAllByStatus([FromQuery] ProjectStatusEnum status, [FromQuery] int Size=5)
        {
            var response = await _adminProjectsService.GetAllProjectsByStatusAdmin(status, Size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("get/freelancer")]
        public async Task<IActionResult> GetAllProjectsByFreelancer([FromQuery] string EmailFreelancer)
        {
            var response = await _adminProjectsService.GetAllProjectsByFreelancerAdmin(EmailFreelancer);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("get/client")]
        public async Task<IActionResult> GetAllProjectsByClient([FromQuery] string EmailClient)
        {
            var response = await _adminProjectsService.GetAllProjectsByClientAdmin(EmailClient);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
