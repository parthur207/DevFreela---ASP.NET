using DevFreela.Application.DTOs;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.DTOs.AdminFreelancerDTOs;

namespace DevFreela.Application.Interfaces.FreeLancerInterface
{
    internal interface IFreelancerProjectInterface
    {
        //Querys

        Task<List<AdminFreelancerProjectDTO>> GetAllMyProjectsAsync(int FreeLanceId);

        //Commands
        Task<SimpleResponseModel> CreateProject(CreateProjectModel ProjectModel, int FreeLanceId);

        Task<SimpleResponseModel> UpdateProject(int Id, UpdateProjectModel ProjectUpdateModel);

        Task<SimpleResponseModel> DeleteProject(int Id);

        Task<SimpleResponseModel> StartProject(int Id);

        Task<SimpleResponseModel> CompleteProject(int Id);

    }
}
