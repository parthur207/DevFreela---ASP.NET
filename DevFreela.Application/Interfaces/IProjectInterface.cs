using DevFreela.Application.Models;
using DevFreela.Application.ViewModels;
using DevFreela.Domain.Entities;


namespace DevFreela.Application.Interfaces
{
    public interface IProjectInterface
    {
         Task<ResponseModel<List<ProjectViewModel>>> GetSearch(string Search);

         Task<ResponseModel<ProjectViewModel>> GetById(int Id);

        Task<ResponseModel<int>> InsertProject(CreateProjectModel ProjectModel);

        Task<ResponseModel<object?>> Update(int Id, UpdateProjectModel ProjectUpdateModel);

        Task<ResponseModel<object?>> Delete(int Id);

        Task<ResponseModel<object?>> Start(int Id);

        Task<ResponseModel<object?>> Complete(int Id);

        Task<ResponseModel<object?>> InsertComment(int id, CreateCommentModel CommentModel);
    }
}
