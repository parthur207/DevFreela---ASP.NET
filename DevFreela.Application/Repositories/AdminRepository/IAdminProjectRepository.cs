using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.AdminRepository
{
    public interface IAdminProjectRepository
    {
        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByStatusAdminAsync(ProjectStatusEnum status, int Size);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetSearchAdminAsync(string Search, int Size);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByFreelancerAdminAsync(string EmailFreelancer);

        Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByClientAdminAsync(string EmailClient);
    }
}
}
