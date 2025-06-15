using DevFreela.Application.Repositories.FreelancerRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.RepositoriesServices.FreelancerRepository
{
    internal class FreelancerProjectsRepositoryService : IFreelancerProjectRepository
    {
        private readonly DevFreelaDbContext _dbContext;
        public FreelancerProjectsRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<ProjectEntity>>> GetAllMyProjectsByNameOrDescriptionAsync(int FreeLanceId, string NameOrDescription, int Size)
        {
            ResponseModel<List<ProjectEntity>> response = new ResponseModel<List<ProjectEntity>>();
            try
            {
                var projects = await _dbContext.Projects
                    .Where(x => x.IdFreeLancer == FreeLanceId &&
                    (string.IsNullOrEmpty(NameOrDescription) || x.Title.Contains(NameOrDescription) || x.Description.Contains(NameOrDescription)))
                    .Take(Size)
                    .ToListAsync();

                if (projects is null || !projects.Any())
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto encontrado a seu vínculo.";
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

        public async Task<ResponseModel<List<ProjectEntity>>> GetAllMyProjectsByStatusAsync(int FreeLanceId, ProjectStatusEnum Status, int Size)
        {
           
            ResponseModel<List<ProjectEntity>> response = new ResponseModel<List<ProjectEntity>>();

            try
            {
                var projects = await _dbContext.Projects
                    .Where(x => x.IdFreeLancer == FreeLanceId && x.Status == Status)
                    .Include(x=>x.Client.FullName)
                     .Include(x => x.Client.Email)
                    .Take(Size)
                    .ToListAsync();

                if (projects is null || !projects.Any())
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto com esse status foi encontrado a seu vínculo.";
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

        public async Task<SimpleResponseModel> CreateProjectAsync(int FreeLanceId, ProjectEntity Entity)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                Entity.AssignFreelancer(FreeLanceId);
                await _dbContext.Projects.AddAsync(Entity);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Projeto criado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> DeleteProjectAsync(int IdProject, int FreelancerId)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project = await _dbContext.Projects.FirstOrDefaultAsync(x=>x.Id== IdProject && x.IdFreeLancer == FreelancerId);

                if (project == null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "PNenhum projeto com essa identificação foi encontrado a seu vínculo.";
                    return response;
                }

                if (project.IdFreeLancer != FreelancerId)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Você não tem permissão para excluir este projeto.";
                    return response;
                }

                var Result=project.SetAsDeleted();

                if (Result is false)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "O projeto ja se encontra excluído.";
                    return response;
                }

                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Projeto excluído com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> MakeProjectAvailableAsync(int IdProject, int FreelancerId)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == IdProject && x.IdFreeLancer == FreelancerId);

                if (project == null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto com essa identificação foi encontrado a seu vínculo.";
                    return response;
                }

                if (project.Status == ProjectStatusEnum.Sold || project.Status == ProjectStatusEnum.PaymentPending)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Erro ao modificar o status do projeto para 'Disponível'. O projeto em questão se encontra vendido, ou em processo de venda.";
                    return response;
                }

                project.MakeAvailable();
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Sucesso. Status do projeto modificado para 'Disponível'.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> StartProjectAsync(int IdProject, int FreelancerId)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == IdProject && x.IdFreeLancer == FreelancerId);

                if (project == null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto com essa identificação foi encontrado a seu vínculo.";
                    return response;
                }

                if (project.Status == ProjectStatusEnum.Sold || project.Status == ProjectStatusEnum.PaymentPending)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Erro ao modificar o status do projeto para 'Em progresso'. O projeto em questão se encontra vendido, ou em processo de venda.";
                    return response;
                }

                project.Start();
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Sucesso. Status do projeto alterado para 'Em andamento'.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> SuspendProjectAsync(int IdProject, int FreelancerId)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == IdProject && x.IdFreeLancer == FreelancerId);

                if (project == null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto com essa identificação foi encontrado a seu vínculo.";
                    return response;
                }

                if (project.Status == ProjectStatusEnum.Sold || project.Status == ProjectStatusEnum.PaymentPending)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Erro ao modificar o status do projeto para 'Suspenso'. O projeto em questão se encontra vendido, ou em processo de venda.";
                    return response;
                }

                project.Suspend();
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Sucesso. Status do projeto modificado para 'Suspenso'.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<SimpleResponseModel> UpdateProjectAsync(int IdProject, int FreelancerId, ProjectEntity Entity)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var project = await _dbContext.Projects.FirstOrDefaultAsync(x => x.Id == IdProject && x.IdFreeLancer == FreelancerId);

                if (project == null)
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhum projeto com essa identificação foi encontrado a seu vínculo.";
                    return response;
                }

                if (project.Status == ProjectStatusEnum.Sold || project.Status == ProjectStatusEnum.PaymentPending)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Erro ao modificar o projeto. O projeto em questão se encontra vendido, ou em processo de venda.";
                    return response;
                }

                project.UpdateProject(Entity.Title, Entity.Description, Entity.TotalCost);
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Sucesso. Projeto atualizado com sucesso.";
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
