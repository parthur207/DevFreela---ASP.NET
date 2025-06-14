using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.Updates;
using DevFreela.Infrastructure.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevFreela.API.Controllers.GenericControllers
{
    [Route("api/generic")]
    [ApiController]
    public class GenericController : ControllerBase
    {

        private readonly IUserGenericInterface _userGenericService;
        private readonly IJwtInterface _jwtService;

        public GenericController(IUserGenericInterface userGenericService, IJwtInterface jwtService)
        {
            _userGenericService = userGenericService;
            _jwtService= jwtService;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var Response = await _userGenericService.LoginGeneric(model);

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }
            var Token = _jwtService.GenerateToken(Response.Content.Item1, nameof(Response.Content.Item2));

            return Ok(new { Message = "Login efetuado com sucesso.", Token = Token });
        }
        

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserModel model)
        {
            var Response = await _userGenericService.RegisterGeneric(model);

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }


        [Authorize(Roles = $"{nameof(RolesTypesEnum.Client)},{nameof(RolesTypesEnum.FreeLancer)}")]
        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordModel model)
        {
            
            var  userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var Response =await _userGenericService.ChangePasswordGeneric(userId, model);

            if (Response.Status is ResponseStatusEnum.Error)
            {
                return BadRequest(Response);
            }

            return Ok(Response);
        }


        [Authorize(Roles = $"{nameof(RolesTypesEnum.Client)},{nameof(RolesTypesEnum.FreeLancer)}")]
        [HttpPut("profile-picture")]
        public async Task<IActionResult> PostProfilePicture([FromQuery]IFormFile FilePicture)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            var description = $"Nome do arquivo: {FilePicture.FileName}, Tamanho do arquivo: {FilePicture.Length}";

            //processar a imagem e implemento do armazenamento do banco de dados
            return Ok(description);
        }
    }
}
