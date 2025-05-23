using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevFreela.Domain.Models;
namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly  IProjectInterface _projectService;

        private readonly DevFreelaDbContext _contextInMemory;

        public ProjectsController(IProjectInterface ProjectService, DevFreelaDbContext ContextInMemory)
        {
            _projectService = ProjectService;
            _contextInMemory = ContextInMemory;
        }

        [HttpPost]
        public IActionResult PostProject(CreateProjectModel Model)
        {
            var entity = Model.ToProjectEntity();

            _contextInMemory.Projects.Add(entity);
            _contextInMemory.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { Id=1}, Model);
        }

        [HttpGet]
        public IActionResult GetSearch(string search ="", int size=3)
        {

            var projects= _contextInMemory.Projects
                .Include(x=>x.Client)
                .Include(x=>x.FreeLancer)
                .Where(x=>!x.IsDeleted && (search== null || x.Title.Contains(search) || x.Description.Contains(search)))
                .Take(size)
                .ToList();

            if(projects is null || !projects.Any())
            {
                return NotFound();
            }

            var model= projects.Select(ProjectMapper.ToProjectModel).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        public  IActionResult GetById(int id)
        {
            var project = _contextInMemory.Projects
                .Include(x => x.Client)
                .Include(x => x.FreeLancer)
                .Include(x => x.Comments)
                .SingleOrDefault(x => x.Id == id);

            if(project is null)
            {
                return NotFound();
            }

            var model = ProjectMapper.ToProjectModel(project);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateProjectModel Model)
        {

            var project = _contextInMemory.Projects.SingleOrDefault(x => x.Id == id);

            if(project is null)
            {
                return NotFound();
            }

            project.Update(Model.Title, Model.Description, Model.TotalCost);

            _contextInMemory.Projects.Update(project);
            _contextInMemory.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            var project = _contextInMemory.Projects.SingleOrDefault(x => x.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            project.SetAsDeleted();

            _contextInMemory.Projects.Update(project);
            _contextInMemory.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}/start")]
        public async Task <IActionResult> Start(int id)
        {
            var project = _contextInMemory.Projects.SingleOrDefault(x => x.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            project.Start();

            _contextInMemory.Projects.Update(project);
            _contextInMemory.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(int id)
        {

            var project = _contextInMemory.Projects.SingleOrDefault(x => x.Id == id);

            if (project is null)
            {
                return NotFound();
            }

            project.Complete();
            _contextInMemory.Projects.Update(project);
            _contextInMemory.SaveChanges();

            return NoContent();
        }



        [HttpPost("coments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentModel Model)
        {
            var project = _contextInMemory.Projects.SingleOrDefault(x => x.Id == Model.IdProject);

            if (project is null)
            {
                return NotFound();
            }

            var NewComment = Model.ToCommentEntity();

            _contextInMemory.ProjectComments.Add(NewComment);
            _contextInMemory.SaveChanges();
            return Created();
        }   
    }
}
