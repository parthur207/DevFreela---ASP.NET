using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.Repositories.FreelancerRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models.Updates;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.RepositoriesServices.FreelancerRepository
{
    internal class FreelancerProjectsRepositoryService : IFreelancerProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public FreelancerProjectsRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SimpleResponseModel> CompleteProjectAsync(int IdProject, int FreelancerId)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project= _dbContext.Projects
                    .FirstOrDefault(x => x.Id == IdProject && x.IdFreeLancer == FreelancerId);

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Status do projeto alterado para ";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response ;
            }
        }

        public async Task<SimpleResponseModel> CreateProjectAsync(int FreeLanceId, ProjectEntity Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> DeleteProjectAsync(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByNameOrDescriptionAsync(int FreeLanceId, string NameOrDescription, int Size)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllMyProjectsByStatusAsync(int FreeLanceId, ProjectStatusEnum Status, int Size)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> MakeProjectAvailableAsync(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> StartProjectAsync(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> SuspendProjectAsync(int IdProject, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> UpdateProjectAsync(int IdProject, int userId, ProjectEntity Entity)
        {
            throw new NotImplementedException();
        }
    }
}
