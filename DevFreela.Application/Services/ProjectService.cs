using DevFreela.Application.DTOs;
using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace DevFreela.Application.Services
{
    public class ProjectService : IProjectInterface
    {

        private readonly FreeLancerTotalCostConfig _values;

        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(IOptions<FreeLancerTotalCostConfig> Config, DevFreelaDbContext DbContext) //MyDbContext DbContext)
        {
            _values = Config.Value;

            _dbContext = DbContext;
        }

        public async Task<SimpleResponseModel> CompleteAsync(int Id)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var project = await _dbContext.Projects
                    .SingleOrDefaultAsync(x => x.Id == Id);

                if (project is null)
                {
                    response.Message = "Projeto inexistente.";
                    response.Status = false;
                    return response;
                }

                project.Complete();
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "O status do projecto foi alterado para 'finalizado'.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<SimpleResponseModel> DeleteAsync(int id)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var projectEntity = _dbContext.Projects
                    .SingleOrDefault(x => x.Id == id);

                if (projectEntity is null)
                {
                    response.Message = "Projeto inexistente.";
                    response.Status = false;
                    return response;
                }

                projectEntity.SetAsDeleted();
                _dbContext.Projects.Update(projectEntity);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "O status do projeto foi modificado para 'Deletado'.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response; 
            }
        }

        public async Task<ResponseModel<ProjectDTO>> GetByIdAsync(int id)
        {

            ResponseModel<ProjectDTO> response = new ResponseModel<ProjectDTO>();
            try
            {
                var project = await _dbContext.Projects
                    .Include(x=>x.Client)
                    .Include(X=>X.Comments)
                    .Include(x=>x.FreeLancer)
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (project is null)
                {
                    response.Status = false;
                    response.Message = "Nenhum projeto foi encontrado.";
                    return response;
                }

                var projectMapped = ProjectMapper.ToProjectDTO(project);

                response.Content = projectMapped;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ProjectItemDTO>>> GetSearchAsync(string Search, int N)
        {
            ResponseModel<List<ProjectItemDTO>> response = new ResponseModel<List<ProjectItemDTO>> { Content = new List<ProjectItemDTO>() };

            try
            {
                var projects=await _dbContext.Projects
                    .Include(x => x.Client)
                    .Include(x => x.FreeLancer)
                    .Where(x => !x.IsDeleted && (Search == null || x.Title.Contains(Search) || x.Description.Contains(Search)))
                    .Take(N)
                    .ToListAsync();

                if (projects is null || projects.Count==0)
                {
                    response.Status = false;
                    response.Message = "Nenhum projeto foi encontrado.";
                    return response;
                }

                foreach (var p in projects)
                {
                    var projectMapped=ProjectMapper.ToProjectItemDTO(p);
                    response.Content.Add(projectMapped);
                }
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<SimpleResponseModel> CreateCommentAsync(int id, CreateCommentModel CommentModel)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var commentEntity = CommentMapper.ToCommentEntity(CommentModel);

                if (commentEntity is null)
                {
                    response.Status = false;
                    response.Message = "Não é possível a criação de comentários nulos.";
                    return response;
                }

                await _dbContext.ProjectComments.AddAsync(commentEntity);
                await _dbContext.SaveChangesAsync();

                response.Message = "Comentário criado com sucesso.";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<SimpleResponseModel> CreateProjectAsync(CreateProjectModel ProjectModel)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var projectEntity = ProjectMapper.ToProjectEntity(ProjectModel);

                if (projectEntity is null)
                {
                    response.Status = false;
                    response.Message = "Ocorreu uma falha na criação do projeto. Certifique que todos os parâmetros estejam preenchidos.";
                    return response;
                }

                await _dbContext.Projects.AddAsync(projectEntity);
                await _dbContext.SaveChangesAsync();

                response.Message = "Projeto criado com sucesso.";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<SimpleResponseModel> StartAsync(int id)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var projectEntity = await _dbContext.Projects.SingleOrDefaultAsync(x=>x.Id==id);

                if (projectEntity is null)
                {
                    response.Status = false;
                    response.Message = "Projeto inexistente.";
                    return response;
                }

                projectEntity.Start();
                _dbContext.Projects.Update(projectEntity);
                await _dbContext.SaveChangesAsync();

                response.Message = "O status do projeto foi alterado para 'Iniciado'.";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<SimpleResponseModel> UpdateAsync(int id, UpdateProjectModel ProjectUpdateModel)
        {

            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == id);

                if (project is null)
                {
                    response.Status = false;
                    response.Message= "Projeto inexistente.";
                    return response;
                }

                project.Update(ProjectUpdateModel.Title, ProjectUpdateModel.Description, ProjectUpdateModel.TotalCost);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "O projeto foi atualizado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                return new SimpleResponseModel
                {
                    Status = false,
                    Message = ex.Message
                };
            }
        }
    }
}