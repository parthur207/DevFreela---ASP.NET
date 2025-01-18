using DevFreela.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DevFreela.Services.Projects
{
    public interface IProjects
    {

        //public Task<ResponseModel<CreateProjectInputModel>> PostProject();

        public Task<ResponseModel<CreateProjectInputModel>> GetSearch(string Search);

        public Task<ResponseModel<CreateProjectInputModel>> GetById(int Id);

        public Task<ResponseModel<UpdateProjectInputModel>> Put(int Id, UpdateProjectInputModel Model);

        //public Task<ResponseModel<CreateProjectInputModel>> Delete(int Id);

        public Task<ResponseModel<CreateProjectInputModel>> Start(int Id);

        public Task<ResponseModel<CreateProjectInputModel>> Complete(int Id);

        public Task<ResponseModel<CreateCommentInputModel>> PostComment();


    }
}
