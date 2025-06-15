using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Repositories.GenericRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.RepositoriesServices.GenericRepository
{
    internal class ProjectGenericRepositoryService : IProjectGenericRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectGenericRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsAsync(string search, int Size)
        {
            
            ResponseModel<List<ProjectEntity>> response = new ResponseModel<List<ProjectEntity>>();
            try
            {
                var projects = await _dbContext.Projects
                    .Where(x => string.IsNullOrEmpty(search) || x.Title.Contains(search) || x.Description.Contains(search))
                    .Take(Size)
                    .ToListAsync();

                if (projects is null || !projects.Any())
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto encontrado";
                    return response;
                }

                response.Content = projects;
                response.Status = ResponseStatusEnum.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByOwnerAsync(string NameOrEmail, int Size)
        {             
            ResponseModel<List<ProjectEntity>> response = new ResponseModel<List<ProjectEntity>>();

            try
            {
                var FreelancerOwner = await _dbContext.Users
                    .Where(x => x.Role == RolesTypesEnum.FreeLancer && x.FullName.Equals(NameOrEmail) || x.Email.Equals(NameOrEmail))
                    .FirstOrDefaultAsync();

                if (FreelancerOwner is null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                var projects = await _dbContext.Projects
                    .Where(p => p.IdFreeLancer == FreelancerOwner.Id)
                    .Take(Size)
                    .ToListAsync();

                if (projects is null || !projects.Any())
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto encontrado para o usuário informado.";
                    return response;
                }

                response.Content = projects;
                response.Status = ResponseStatusEnum.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> CreateCommentProjectAsync(int UserId, ProjectCommentEntity Entity)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var userExists = await _dbContext.Users.AnyAsync(x => x.Id == UserId);
                
                if (!userExists)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                
                await _dbContext.ProjectComments.AddAsync(Entity);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Comentário postado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }
    }
}   
