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

        public Task<ResponseModel<object?>> Complete(int Id)
        {
            ResponseModel<object?> response = new ResponseModel<object?>();
        }

        public Task<ResponseModel<object?>> Delete(int Id)
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