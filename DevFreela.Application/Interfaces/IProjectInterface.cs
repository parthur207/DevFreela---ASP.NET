using DevFreela.Application.DTOs;
using DevFreela.Domain.Models;
using DevFreela.Domain.Models.ResponsePattern;


namespace DevFreela.Application.Interfaces
{
    public interface IProjectInterface
    {
        Task<ResponseModel<List<ProjectItemDTO>>> GetSearchAsync(string Search, int N);

        Task<ResponseModel<ProjectDTO>> GetByIdAsync(int Id);

        Task<SimpleResponseModel> CreateProjectAsync(CreateProjectModel ProjectModel);

        Task<SimpleResponseModel> UpdateAsync(int Id, UpdateProjectModel ProjectUpdateModel);

        Task<SimpleResponseModel> DeleteAsync(int Id);

        Task<SimpleResponseModel> StartAsync(int Id);

        Task<SimpleResponseModel> CompleteAsync(int Id);

        Task<SimpleResponseModel> CreateCommentAsync(int id, CreateCommentModel CommentModel);
    }
}
