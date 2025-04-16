using DevFreela.Models;
using DevFreela.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly DevFreelaDbContext _dbContextInMemory;

        public UsersController(DevFreelaDbContext devFreelaDbContext)
        {
            _dbContextInMemory = devFreelaDbContext;
        }


        [HttpGet]

        public async Task<IActionResult> GetById(int id)
        {
            var UserEntity = _dbContextInMemory.Users
                .SingleOrDefault(x => x.Id == id);
            var UserModel= UserEntity.ToUserModel();


            return Ok(UserModel);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserModel model)
        {

            var UserEntity = model.ToUserEntity();
            _dbContextInMemory.Users.Add(UserEntity);
            _dbContextInMemory.SaveChanges();

            return NoContent();
        }

        [HttpPost("{Id}/skills")]
        public async Task<IActionResult> PostSkills(UserSkillModel Model)
        {
            var UserSkillEntity = Model.ToUserSkillEntity();
            _dbContextInMemory.UserSkills.Add(UserSkillEntity);
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
