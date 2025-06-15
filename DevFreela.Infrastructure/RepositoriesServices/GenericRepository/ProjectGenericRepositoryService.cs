using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Repositories.GenericRepository;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Infrastructure.Persistence;
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

        public async Task<SimpleResponseModel> CreateCommentProjectAsync(int UserId, CreateCommentModel CommentModel)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProjectDTO>>> GetAllProjectsAsync(string search, int Size)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<ProjectDTO>>> GetAllProjectsByOwnerAsync(string NameOrEmail, int Size)
        {
            throw new NotImplementedException();
        }
    }
}
