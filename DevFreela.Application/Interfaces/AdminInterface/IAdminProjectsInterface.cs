using DevFreela.Application.DTOs.AdminDTOs;
using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models;
using DevFreela.Domain.Models.PatternResult;

namespace DevFreela.Application.Interfaces.AdminInterface
{
    public interface IAdminProjectsInterface
    {
        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByStatusAdmin(ProjectStatusEnum status, int Size);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetSearchAdmin(string Search, int Size);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByFreelancerAdmin(string EmailFreelancer);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByClientAdmin(string EmailClient);
    }
}
