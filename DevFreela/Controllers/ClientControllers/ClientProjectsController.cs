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


        [HttpGet("getPurchased")]
        public async Task<IActionResult> GetPurchasedProjects([FromQuery] string search = "", [FromQuery] int size = 3)
        {

            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            //var response = 

            if (response.Status is false)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("getPurchased/{nameOrDescription}")]


        [HttpPatch("Buy/{idProject}")]
        public async Task<IActionResult> BuyProject([FromRoute] int idProject)
        {
          
            //var response = 

            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPatch("Pay/{idProject}")]
        public async Task<IActionResult> MakePayment([FromRoute] int idProject)
        {
            //var response = 

            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPatch("cancel/purchase/{idProject}")]
        public async Task<IActionResult> CancelPurchase([FromRoute] int idProject)
        {
            //var response = 

            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }


    }
}
