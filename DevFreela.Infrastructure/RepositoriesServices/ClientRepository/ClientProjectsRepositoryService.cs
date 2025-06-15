using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Repositories.ClientRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.RepositoriesServices.ClientRepository
{
    internal class ClientProjectsRepositoryService : IClientProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public ClientProjectsRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<UserProjectEntity>>> GetPurchasedProjectsClientAsync(int idUser, string search, int Size)
        {
            ResponseModel<List<UserProjectEntity>> response = new ResponseModel<List<UserProjectEntity>>();
            try
            {
                var query = _dbContext.UserProjects
                    .Include(x => x.Project)
                    .Where(x => x.IdUser == idUser);

                if (!string.IsNullOrWhiteSpace(search))
                {
                    query = query.Where(x => x.Project.Title.Contains(search));
                }

                var projects = await query
                    .OrderByDescending(x => x.PurchaseDate)
                    .Take(Size)
                    .ToListAsync();

                if (projects is null || !projects.Any())
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto adquirido encontrado.";
                    return response;
                }

                response.Content = projects;
                response.Status = ResponseStatusEnum.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> BuyProjectClientAsync(int IdUser, int IdProject)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var HasProject = await _dbContext.Projects.AnyAsync(x=>x.Id == IdProject);

                if (!HasProject)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Projeto não encontrado.";
                    return response;
                }

                var projectById = await _dbContext.Projects
                    .FirstOrDefaultAsync(x => x.Id == IdProject && 
                    x.Status != ProjectStatusEnum.Available);

                if (projectById is null)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "O projeto informando não está disponível para compra.";
                    return response;
                }

                if (projectById.IdFreeLancer == IdUser)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Você não pode comprar seu próprio projeto.";
                    return response;
                }

                projectById.SetPaymentPending();
                projectById.AssignBuyer(IdUser);
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Sucesso! Efetue o pagamento para processar a aquisição do projeto.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> CancelPurchaseClientAsync(int IdUser, int IdProject)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project = await _dbContext.Projects.Where(x=>x.Id == IdProject && x.Id == IdUser && x.Status == ProjectStatusEnum.PaymentPending).FirstOrDefaultAsync();

                if (project is null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Não foi encontrado nenhum projeto com essa identificação vinculado a seu usuário.";
                    return response;
                }

                if (project.IdFreeLancer == IdUser)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Voce não possui vínculo como comprador ao projeto informado.";
                    return response;
                }

                project.UpdateProject();
                project.MakeAvailable();
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Compra cancelada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

     
        public async Task<SimpleResponseModel> MakePaymentClientAsync(int IdUser, int IdProject)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var project = await _dbContext.Projects.Where(x => x.Id == IdProject && x.IdClient == IdUser && x.Status == ProjectStatusEnum.PaymentPending).FirstOrDefaultAsync();

                if (project is null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Não foi encontrado nenhum projeto com essa identificação vinculado a seu usuário.";
                    return response;
                }

                if (project.IdFreeLancer == IdUser)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Voce não possui vínculo como comprador ao projeto informado.";
                    return response;
                }

                project.MakeAsSold();
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Pagamento realizado com sucesso.";
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
