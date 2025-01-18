using DevFreela.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
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
