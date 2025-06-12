using DevFreela.Application.DTOs;
using DevFreela.Domain.Models;
using DevFreela.Domain.Models.ResponsePattern;


namespace DevFreela.Application.Interfaces.AdminInterface
{
    public interface IAdminProjectInterface
    {
        Task<ResponseModel<List<ProjectItemDTO>>> GetSearch(string Search, int N);

        Task<ResponseModel<ProjectDTO>> GetByProjectId(int Id);

        Task<SimpleResponseModel> CreateProject(CreateProjectModel ProjectModel, int FreeLanceId);

        Task<SimpleResponseModel> UpdateProject(int Id, UpdateProjectModel ProjectUpdateModel);

        Task<SimpleResponseModel> DeleteProject(int Id);

        Task<SimpleResponseModel> StartProject(int Id);

        Task<SimpleResponseModel> CompleteProject(int Id);

        Task<SimpleResponseModel> CreateCommentProject(int Id, CreateCommentModel CommentModel);
    }
}
