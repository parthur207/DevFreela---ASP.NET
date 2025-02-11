using DevFreela.Models;
using DevFreela.Persistence;
using DevFreela.Services.Projects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace DevFreela.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly  IProjects _projectService;

        private readonly DevFreelaDbContext _contextInMemory;

        public ProjectsController(IProjects ProjectService, DevFreelaDbContext ContextInMemory)
        {
            _projectService = ProjectService;
            _contextInMemory = ContextInMemory;
        }

        [HttpPost("{ProjectModel}")]
        public IActionResult PostProject(CreateProjectModel Model)
        {
            var entity = Model.ToProjectEntity();

            _contextInMemory.Projects.Add(entity);
            _contextInMemory.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { Id=1}, Model);
        }

        [HttpGet]
        public IActionResult GetSearch(string search="")
        {

            var projects= _contextInMemory.Projects
                .Include(x=>x.Client)
                .Include(x=>x.FreeLancer)
                .Where(x=>!x.IsDeleted).ToList();

            var model = projects.Select(ProjectItemViewModel.ToProjectModel).ToList();

            return Ok(model);
        }

        [HttpGet("{Id}")]
        public  IActionResult GetById(int Id)
        {
            var project = _contextInMemory.Projects
                .Include(x => x.Client)
                .Include(x => x.FreeLancer)
                .Include(x => x.Comments)
                .SingleOrDefault(x => x.Id == Id);

            var model = ProjectViewModel.ToProjectModel(project);

            return Ok(model);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, UpdateProjectModel Model)
        {

            Model.IdProject = Id;

            return NoContent();
        }

        [HttpDelete("{Id}")]
        public async Task <IActionResult> Delete(int Id)
        {
            return Ok();
        }

        [HttpPut("{Id}/start")]
        public async Task <IActionResult> Start(int Id)
        {
            return NoContent();
        }

        [HttpPut("{Id}/complete")]
        public async Task<IActionResult> Complete(int Id)
        {
            return NoContent();
        }



        [HttpPost("coments/{Id}")]
        public async Task<IActionResult> PostComment(int Id, CreateCommentModel Model)
        {
            return Created();
        }   
    }
}
