﻿using DevFreela.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using DevFreela.Domain.Models;
namespace DevFreela.API.Controllers
{

    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        private readonly  IProjectInterface _projectService;

        public ProjectsController(IProjectInterface ProjectService)
        {
            _projectService = ProjectService;
        }

        [HttpPost]
        public async Task<IActionResult> PostProject([FromBody]CreateProjectModel Model)
        {
            var response = await _projectService.CreateProjectAsync(Model);
            if (response.Status is false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("get/search")]
        public async Task<IActionResult> GetSearch([FromQuery] string search ="", [FromQuery] int size=3)
        {

            var response= await _projectService.GetSearchAsync(search, size);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("get/{idProject}")]
        public  async Task<IActionResult> GetById([FromRoute] int idProject)
        {
            var response= await _projectService.GetByIdAsync(idProject);

            if (response.Status is false)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]UpdateProjectModel Model)
        {
            var response = await _projectService.UpdateAsync(id, Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task <IActionResult> Delete([FromRoute] int id)
        {
          var response = await _projectService.DeleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("start/{id}")]
        public async Task <IActionResult> Start([FromRoute] int id)
        {
            var response= await _projectService.StartAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPut("complete/{id}")]
        public async Task<IActionResult> Complete([FromRoute]int id)
        {

            var response= await _projectService.CompleteAsync(id);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }


        [HttpPost("coments")]
        public async Task<IActionResult> PostComment([FromBody] CreateCommentModel Model)
        {
            var response= await _projectService.CreateCommentAsync(Model.IdProject, Model);

            if (response.Status is false)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }   
    }
}
