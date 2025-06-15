using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Application.Repositories.GenericRepository;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models.Updates;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.RepositoriesServices.GenericRepository
{
    internal class UserGenericRepositoryService : IUserGenericRepository
    {

        private readonly DevFreelaDbContext _dbContext;
        public UserGenericRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SimpleResponseModel> ChangePasswordGenericAsync(int UserId, UpdatePasswordModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<(int, RolesTypesEnum)>> LoginGenericAsync(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> RegisterGenericAsync(CreateUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
