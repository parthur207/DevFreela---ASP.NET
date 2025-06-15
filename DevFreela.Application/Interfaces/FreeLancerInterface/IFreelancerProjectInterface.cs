using DevFreela.Application.DTOs;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.Updates;
using DevFreela.Domain.Models.PatternResult;

namespace DevFreela.Application.Interfaces.FreeLancerInterface
{
    public interface IFreelancerProjectInterface
    {
        //Querys
        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByNameOrDescription(int FreeLanceId, string NameOrDescription, int Size);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByStatus(int FreeLanceId, ProjectStatusEnum Status, int Size);

        //Commands
        Task<SimpleResponseModel> CreateProject(int FreeLanceId, CreateProjectModel ProjectModel);

        Task<SimpleResponseModel> UpdateProject(int IdProject, int userId, UpdateProjectModel model);

        Task<SimpleResponseModel> DeleteProject(int IdProject, int userId);

        Task<SimpleResponseModel> StartProject(int IdProject, int userId);

        Task<SimpleResponseModel> SuspendProject(int IdProject, int userId);

        Task<SimpleResponseModel> MakeProjectAvailable(int IdProject, int userId);

    }
}
