using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.Interfaces.FreeLancerInterface;
using DevFreela.Application.Repositories.FreelancerRepository;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models.Updates;

namespace DevFreela.Application.Services.FreelancerService
{
    internal class FreelancerProjectsService : IFreelancerProjectInterface
    {

        private readonly IFreelancerProjectRepository _freelancerProjectsRepository;

        public FreelancerProjectsService(IFreelancerProjectRepository freelancerProjectsRepository)
        {
            _freelancerProjectsRepository = freelancerProjectsRepository;
        }

        public Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByNameOrDescription(int FreeLanceId, string NameOrDescription, int Size)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByStatus(int FreeLanceId, ProjectStatusEnum Status, int Size)
        {
            throw new NotImplementedException();
        }


        public Task<SimpleResponseModel> CreateProject(int FreeLanceId, CreateProjectModel ProjectModel)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> DeleteProject(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }


        public Task<SimpleResponseModel> MakeProjectAvailable(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> StartProject(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> SuspendProject(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> UpdateProject(int IdProject, int userId, UpdateProjectModel model)
        {
            throw new NotImplementedException();
        }
    }
}
