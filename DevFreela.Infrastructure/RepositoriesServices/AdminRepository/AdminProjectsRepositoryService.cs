using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.Repositories.AdminRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.RepositoriesServices.AdminRepository
{
    public class AdminProjectsRepositoryService : IAdminProjectRepository
    {

        private readonly DevFreelaDbContext _dbContext;
        public AdminProjectsRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByClientAdminAsync(string EmailClient)
        {
            ResponseModel<List<ProjectEntity>> Response = new ResponseModel<List<ProjectEntity>>();
           
            try
            {
                var ClientEntity = await _dbContext.Users
                    .Where(c => c.Email == EmailClient)
                    .FirstOrDefaultAsync();

                if (ClientEntity is null)
                {
                    Response.Message = "Cliente não encontrado.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                var ProjectsByClient = await _dbContext.Projects.Where(x => x.IdClient == ClientEntity.Id).ToListAsync();


                if (ProjectsByClient is null || !ProjectsByClient.Any())
                {
                    Response.Message = "O usuário informado não fez aquisição de nenhum produto.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }


                Response.Content = ProjectsByClient;
                Response.Status = ResponseStatusEnum.Success;
                return Response;

            }
            catch (Exception Ex)
            {

                Response.Status= ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {Ex.Message}";
                return Response;
            }
        }

        public async Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByFreelancerAdminAsync(string EmailFreelancer)
        {
            ResponseModel<List<ProjectEntity>> Response = new ResponseModel<List<ProjectEntity>>();
            try
            {
                var FreelancerEntity = await _dbContext.Users
                    .Where(x => x.Email == EmailFreelancer && x.Role==RolesTypesEnum.FreeLancer)
                    .FirstOrDefaultAsync();

                if (FreelancerEntity is null)
                {
                    Response.Message = "Freelancer não encontrado.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                var ProjectsByFreelancer = await _dbContext.Projects.Where(x => x.Id == FreelancerEntity.Id).ToListAsync();

                if (ProjectsByFreelancer is null || !ProjectsByFreelancer.Any())
                {
                    Response.Message = "O usuário informado não fez aquisição de nenhum produto.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                Response.Content = ProjectsByFreelancer;
                Response.Status = ResponseStatusEnum.Success;
                return Response;

            }
            catch (Exception ex)
            {

                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }

        public async Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByStatusAdminAsync(ProjectStatusEnum status, int Size)
        {
            ResponseModel<List<ProjectEntity>> Response = new ResponseModel<List<ProjectEntity>>();
            try
            {
                var ProjectsByStatus = await _dbContext.Projects
                    .Where(x => x.Status == status)
                    .Take(Size)
                    .ToListAsync();

                if (ProjectsByStatus is null || !ProjectsByStatus.Any())
                {
                    Response.Message = "Nenhum projeto encontrado com o status informado.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                Response.Content = ProjectsByStatus;
                Response.Status = ResponseStatusEnum.Success;
                return Response;

            }
            catch (Exception ex)
            {

                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }

        public async Task<ResponseModel<List<ProjectEntity>>> GetSearchAdminAsync(string Search, int Size)
        {
            
            ResponseModel<List<ProjectEntity>> Response = new ResponseModel<List<ProjectEntity>>();
            try
            {

                List<ProjectEntity>? ListProjects = new List<ProjectEntity>();

                if (string.IsNullOrEmpty(Search))
                {
                    ListProjects = await _dbContext.Projects
                    .Where(x=>x.IsDeleted==false)
                    .Include(x => x.Client)
                    .Include(x => x.FreeLancer)
                    .Take(Size)
                    .ToListAsync();
                }

                    ListProjects = await _dbContext.Projects
                    .Where(x => x.Title.Contains(Search) || x.Description.Contains(Search))
                    .Take(Size)
                    .ToListAsync();

                if (ListProjects is null || !ListProjects.Any())
                {
                    Response.Message = "Nenhum projeto encontrado com a pesquisa informada.";
                    Response.Status = ResponseStatusEnum.NotFound;
                    return Response;
                }

                Response.Content = ListProjects;
                Response.Status = ResponseStatusEnum.Success;
                return Response;

            }
            catch (Exception ex)
            {

                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }
    }
}
