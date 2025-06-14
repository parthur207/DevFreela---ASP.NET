using DevFreela.Application.Interfaces.ClientInterface;
using DevFreela.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers.ClientControllers
{
    [Route("api/client/projects")]
    [ApiController]
    [Authorize(Roles = nameof(RolesTypesEnum.Client))]
    public class ClientProjectsController : ControllerBase
    {

        private readonly IClientProjectsInterface _clientProjectsService;

        public ClientProjectsController(IClientProjectsInterface clientProjectsService)
        {
            _clientProjectsService = clientProjectsService;
        }


        [HttpGet("getPurchased")]
        public async Task<IActionResult> GetPurchasedProjects([FromQuery] string nameOrDescription = "", [FromQuery] int size = 3)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Response =  await _clientProjectsService.GetPurchasedProjectsClient(userId, nameOrDescription, size);

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


        [HttpPatch("Buy/{idProject}")]
        public async Task<IActionResult> BuyProject([FromRoute] int idProject)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Response = await _clientProjectsService.BuyProjectClient(userId, idProject);

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

        [HttpPatch("Pay/{idProject}")]
        public async Task<IActionResult> MakePayment([FromRoute] int idProject)
        {

            int UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Response = await _clientProjectsService.MakePaymentClient(UserId, idProject);

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

        [HttpPatch("cancel/purchase/{idProject}")]
        public async Task<IActionResult> CancelPurchase([FromRoute] int idProject)
        {

            int UserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Response = await _clientProjectsService.CancelPurchaseClient(UserId, idProject);

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


    }
}
