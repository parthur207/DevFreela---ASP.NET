using DevFreela.Domain.Enums;
using DevFreela.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers.GenericControllers
{
    [Route("api/generic")]
    [ApiController]
    public class GenericController : ControllerBase
    {

        //private readonly _IAuth

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            //var response = await _authService.LoginService(model);


            return Ok();
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model)
        {
            //var response = await _authService.RegisterService(model);

            if (/*response.Status is false*/ false) // Replace with actual condition
            {
                return BadRequest(/*response*/); // Replace with actual response
            }
            return Ok(/*response*/); // Replace with actual response

        }

        [Authorize(Roles = $"{nameof(RolesTypesEnum.Client)},{nameof(RolesTypesEnum.FreeLancer)}")]
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordModel model)
        {
            //var response = await _authService.ForgotPasswordService(model);

            if (/*response.Status is false*/ false) // Replace with actual condition
            {
                return BadRequest(/*response*/); // Replace with actual response
            }
            return Ok(/*response*/); // Replace with actual response
        }

        [Authorize(Roles = $"{nameof(RolesTypesEnum.Client)},{nameof(RolesTypesEnum.FreeLancer)}")]
        [HttpPut("profile-picture")]
        public async Task<IActionResult> PostProfilePicture([FromQuery]IFormFile FilePicture)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var description = $"file name: {FilePicture.FileName}, file size: {FilePicture.Length}";

            //processar a imagem e implemento do armazenamento do banco de dados
            return Ok(description);
        }
    }
}
