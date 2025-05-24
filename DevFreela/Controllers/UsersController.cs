using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/users")]

    //www.{}/{cadastro/login}/api/users/post
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _dbContextInMemory;
        private readonly IUserInterface _userInterface;

        public UsersController(DevFreelaDbContext devFreelaDbContext)
        {
            _dbContextInMemory = devFreelaDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response= await _userInterface.GetAllUsersAsync();

            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

          
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserModel model)
        {

            return NoContent();
        }

        [HttpPost("{id}/userSkills")]
        public async Task<IActionResult> PostUserSkills(int id, UserSkillModel Model)
        {
            return NoContent();
        }

        [HttpPut("{id}/profile-picture")]
        public async Task<IActionResult> PostProfilePicture(IFormFile FilePicture)
        {
            
            var description = $"file name: {FilePicture.FileName}, file size: {FilePicture.Length}";

            //processar a imagem e implemento do armazenamento do banco de dados
            return Ok(description);    
        }
    }
}
