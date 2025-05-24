using DevFreela.Application.DTOs;
using DevFreela.Domain.Models;


namespace DevFreela.Application.Interfaces
{
    public interface IProjectInterface
    {
        Task<ResponseModel<List<ProjectItemDTO>>> GetSearch(string Search, int N);

        Task<ResponseModel<ProjectDTO>> GetById(int Id);

        Task<SimpleResponseModel> InsertProject(CreateProjectModel ProjectModel);

        Task<SimpleResponseModel> Update(int Id, UpdateProjectModel ProjectUpdateModel);

        Task<SimpleResponseModel> Delete(int Id);

        Task<SimpleResponseModel> Start(int Id);

        Task<SimpleResponseModel> Complete(int Id);

        Task<SimpleResponseModel> InsertComment(int id, CreateCommentModel CommentModel);
    }
}
