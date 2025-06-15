using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.FreelancerRepository
{
    public interface IFreelancerProjectRepository
    {
        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByNameOrDescriptionAsync(int FreeLanceId, string NameOrDescription, int Size);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByStatusAsync(int FreeLanceId, ProjectStatusEnum Status, int Size);

        //Commands
        Task<SimpleResponseModel> CreateProjectAsync(int FreeLanceId, ProjectEntity Entity);

        Task<SimpleResponseModel> UpdateProjectAsync(int IdProject, int userId, ProjectEntity Entity);

        Task<SimpleResponseModel> DeleteProjectAsync(int IdProject, int userId);

        Task<SimpleResponseModel> StartProjectAsync(int IdProject, int userId);

        Task<SimpleResponseModel> CompleteProjectAsync(int IdProject, int userId);

        Task<SimpleResponseModel> SuspendProjectAsync(int IdProject, int userId);

        Task<SimpleResponseModel> MakeProjectAvailableAsync(int IdProject, int userId);
    }
}
