using DevFreela.Application.Mappers;
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

        public UsersController(DevFreelaDbContext devFreelaDbContext)
        {
            _dbContextInMemory = devFreelaDbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {

            var users = _dbContextInMemory.Users
                .Include(X => X.Skills)
                    .ThenInclude(x => x.Skill)
                .Include(x => x.OwnedProjects)
                .Include(X => X.FreeLancerProjects)
            .ToList();

            var usersmodel =users.Select(UserMapper.ToUserViewModel).ToList();

            if (usersmodel is null || !usersmodel.Any())
            {
                return NotFound();
            }

            return Ok(usersmodel);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var UserEntity = _dbContextInMemory.Users
                .Include(x => x.Skills)
                    .ThenInclude(x => x.Skill)
                .Where(x => x.Id == id);

           

            var UserModel= UserEntity.Select(UserMapper.ToUserViewModel).SingleOrDefault();

            if (UserModel is null)
            {
                return NotFound();
            }

            return Ok(UserModel);
        }
        [HttpPost]
        public async Task<IActionResult> PostUser(CreateUserModel model)
        {

            var UserEntity = model.ToUserEntity();
            _dbContextInMemory.Users.Add(UserEntity);
            _dbContextInMemory.SaveChanges();

            return NoContent();
        }

        [HttpPost("{id}/skills")]
        public async Task<IActionResult> PostSkills(int id, UserSkillModel Model)
        {
            var UserSkill = Model.SkillsIds.Select(x=>new UserSkillEntity(id, x)).ToList();
            _dbContextInMemory.UserSkills.AddRange(UserSkill);
            _dbContextInMemory.SaveChanges();
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
