using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Domain.Entities;
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
        Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByStatusAdminAsync(ProjectStatusEnum status, int Size);

        Task<ResponseModel<List<ProjectEntity>>> GetSearchAdminAsync(string Search, int Size);

        Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByFreelancerAdminAsync(string EmailFreelancer);

        Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByClientAdminAsync(string EmailClient);
    }
}
}
