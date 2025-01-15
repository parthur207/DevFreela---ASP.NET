using DevFreela.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Services.Projects
{
    public interface IProjects
    {

        public Task<ActionResult<ResponseModel<CreateProjectInputModel>>> PostProject();

        public Task<ActionResult<ResponseModel<List<CreateProjectInputModel>>>> GetSearch(string Search);

        public Task<ActionResult<ResponseModel<CreateProjectInputModel>>> GetById(int Id);

        public Task<ActionResult<ResponseModel<UpdateProjectInputModel>>> Put(int Id, UpdateProjectInputModel Model);

        public Task<ActionResult<ResponseModel<CreateProjectInputModel>>> Delete(int Id);

        public Task<ActionResult<ResponseModel<CreateProjectInputModel>>> Start(int Id);

        public Task<ActionResult<ResponseModel<CreateProjectInputModel>>> Complete(int Id);

        public Task<ActionResult<ResponseModel<CreateCommentInputModel>>> PostComment();


    }
}
