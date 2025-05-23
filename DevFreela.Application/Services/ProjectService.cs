using DevFreela.Application.DTOs;
using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
using DevFreela.Application.ViewModels;
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

        public async Task<SimpleResponseModel> Complete(int Id)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var project = await _dbContext.Projects
                    .SingleOrDefaultAsync(x => x.Id == Id);

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

        public async Task<SimpleResponseModel> Delete(int Id)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var project = _dbContext.Projects
                    .SingleOrDefault(x => x.Id == Id);

                project.SetAsDeleted();
                _dbContext.Projects.Update(project);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "O projecto foi deletado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response; 
            }
        }

        public async Task<ResponseModel<ProjectItemDTO>> GetById(int id)
        {

            ResponseModel<ProjectItemDTO> response = new ResponseModel<ProjectItemDTO>();
            try
            {
                var project = await _dbContext.Projects
                    .Include(x=>x.Client)
                    .Include(x=>x.FreeLancer)
                    .SingleOrDefaultAsync(x => x.Id == id);

                if (project is null)
                {
                    response.Status = false;
                    response.Message = "Nenhum projeto foi encontrado.";
                    return response;
                }

                var projectMapped = ProjectMapper.ToProjectItemModel(project);

                response.Content = projectMapped;
                response.Status = true;
                response.Message = string.Empty;
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<ProjectDTO>>> GetSearch(string Search, int N)
        {
            ResponseModel<List<ProjectDTO>> response = new ResponseModel<List<ProjectDTO>>();

            try
            {
                var projects=await _dbContext.Projects
                    .Include(x => x.Client)
                    .Include(x => x.FreeLancer)
                    .Where(x => !x.IsDeleted && (Search == null || x.Title.Contains(Search) || x.Description.Contains(Search)))
                    .Take(N)
                    .ToListAsync(); 
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<SimpleResponseModel> InsertComment(int id, CreateCommentModel CommentModel)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var commentEntity = Comment.ToCommentEntity(id);

                await _dbContext.Comments.AddAsync();

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

        public Task<SimpleResponseModel> InsertProject(CreateProjectModel ProjectModel)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> Start(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> Update(int id, UpdateProjectModel ProjectUpdateModel)
        {

            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                var project = await _dbContext.Projects.SingleOrDefaultAsync(x => x.Id == id);

                if (project is null)
                {
                    response.Status = false;
                    response.Message= "Nenhum projeto foi encontrado.";
                    return response;
                }

                project.Update(ProjectUpdateModel.Title, ProjectUpdateModel.Description, ProjectUpdateModel.TotalCost);

                await _dbContext.Projects.AddAsync(project);
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