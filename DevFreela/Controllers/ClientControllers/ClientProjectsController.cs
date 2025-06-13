using DevFreela.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers.ClientControllers
{
    [Route("api/client/projects")]
    [ApiController]
    [Authorize(Roles = nameof(RolesTypesEnum.Client))]
    public class ClientProjectsController : ControllerBase
    {

        [HttpPut("Buy")]
        public async Task<IActionResult> BuyProject([FromBody] int idProject)
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
