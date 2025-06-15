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

        public async Task<ResponseModel<List<ProjectEntity>>> GetPurchasedProjectsClientAsync(int IdUser, string search, int Size)
        {
            ResponseModel<List<ProjectEntity>> response = new ResponseModel<List<ProjectEntity>>();
            try
            {
                var projects = _dbContext.Projects
                    .Where(p => p.Id == IdUser && (string.IsNullOrEmpty(search) || p.Title.Contains(search)))
                    .Take(Size)
                    .ToList();

                if (projects is null || !projects.Any())
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto adiquirido";
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

        public async Task<SimpleResponseModel> BuyProjectClientAsync(int IdUser, int IdProject)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project = await _dbContext.Projects.FindAsync(IdProject);

                if (project == null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Projeto não encontrado.";
                    return response;
                }

                var project2 = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == IdProject && x.Status != ProjectStatusEnum.Available|| x.Status != ProjectStatusEnum.InProgress || x.Status!= ProjectStatusEnum.Created);

                if (project2 is null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "O projeto informando não está disponível para compra.";
                    return response;
                }

                if (project.IdFreeLancer == IdUser)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Você não pode comprar seu próprio projeto.";
                    return response;
                }

                project.SetPaymentPeding();
                project.AssignBuyer(IdUser);
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
                var project = await _dbContext.Projects.Where(x=>x.Id == IdProject && x.IdClient == IdUser && x.Status == ProjectStatusEnum.PaymentPending).FirstOrDefaultAsync();

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

                project.UnassignBuyer();
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
