using DevFreela.Application.Interfaces;
using DevFreela.Application.Models;
using DevFreela.Application.ViewModels;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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

        public async Task<ResponseModel<ProjectViewModel>> Complete(int Id)
        {
            ResponseModel<ProjectViewModel> response = new ResponseModel<ProjectViewModel>();

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
                response.Content = null;
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<ProjectViewModel>> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<ProjectViewModel>> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProjectViewModel>>> GetSearch(string Search)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<object?>> InsertComment(int id, CreateCommentModel CommentModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<int>> InsertProject(CreateProjectModel ProjectModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<object?>> Start(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<object?>> Update(int Id, UpdateProjectModel ProjectUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}