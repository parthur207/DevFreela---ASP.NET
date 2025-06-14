using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Application.Repositories.Admin;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.AdminService
{
    internal class AdminProjectsService : IAdminProjectsInterface
    {
        public Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByClientAdmin(string EmailClient)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByFreelancerAdmin(string EmailFreelancer)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByStatusAdmin(ProjectStatusEnum status, int Size)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetSearchAdmin(string Search, int Size)
        {
            throw new NotImplementedException();
        }
    }
}
}
