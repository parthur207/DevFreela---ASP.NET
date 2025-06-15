using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Application.Repositories.GenericRepository;
using DevFreela.Domain.Entities;
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

        public async Task<SimpleResponseModel> ChangePasswordGenericAsync(int UserId, UserEntity Entity)
        {
            SimpleResponseModel Response = new SimpleResponseModel();

            var user = await _dbContext.Users.FindAsync(UserId);

            if (user == null)
            {
                Response.Message = "Ocorreu um erro na tentativa de alteração da senha.";
                Response.Status = ResponseStatusEnum.Error;
                return Response;
            }

            user.
            _dbContext.Users.Update(user);
            await _dbContext.SaveChangesAsync();

            return new SimpleResponseModel
            {
                Success = true,
                Message = "Password changed successfully."
            };
        }

        public async Task<ResponseModel<(int, RolesTypesEnum)>> LoginGenericAsync(UserEntity Entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SimpleResponseModel> RegisterGenericAsync(UserEntity Entity)
        {
            throw new NotImplementedException();
        }
    }
}
