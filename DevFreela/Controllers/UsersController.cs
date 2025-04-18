using DevFreela.Entities;
using DevFreela.Models;
using DevFreela.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Controllers
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


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {

            var UserEntity = _dbContextInMemory.Users
                .Include(x => x.Skills)
                    .ThenInclude(x => x.Skill)
                .SingleOrDefault(x => x.Id == id);

            if(UserEntity is null)
            {
                return NotFound();
            }

            var UserModel= UserViewModel.ToUserViewModel(UserEntity);


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
            var UserSkillEntity = Model.SkillsIds.Select(x=>new UserSkillEntity(id, x)).ToList();
            _dbContextInMemory.UserSkills.AddRange(UserSkillEntity);
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
