using DevFreela.Application.Interfaces;
using DevFreela.Application.Models;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/users")]

    //www.{domínio}/{cadastro/login}/api/users/
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _dbContextInMemory;
        private readonly IUserInterface _userInterface;
        private readonly IUserSkillInterface _userSkillInterface;

        public UsersController(DevFreelaDbContext devFreelaDbContext,IUserInterface userInterface, IUserSkillInterface userSkillInterface)
        {
            _dbContextInMemory = devFreelaDbContext;
            _userInterface = userInterface;
            _userSkillInterface = userSkillInterface;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUsers()
        {
            var response= await _userInterface.GetAllUsersAsync();

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }


        [HttpGet("email")]
        public async Task<IActionResult> GetById([FromQuery] string email)
        {
            var response= await _userInterface.GetByEmailAsync(email);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] CreateUserModel model)
        {
            var response = await _userInterface.CreateUserAsync(model);

            if (response.Status is false) 
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("userSkills")]
        public async Task<IActionResult> PostUserSkills([FromBody] UserSkillModel Model)
        {
            var response = await _userSkillInterface.CreateUserSkillAsync(Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }
        return Ok(response);
        }

        [HttpPut("{id}/profile-picture")]
        public async Task<IActionResult> PostProfilePicture([FromRoute] int id, IFormFile FilePicture)
        {
            
            var description = $"file name: {FilePicture.FileName}, file size: {FilePicture.Length}";

            //processar a imagem e implemento do armazenamento do banco de dados
            return Ok(description);    
        }
    }
}
