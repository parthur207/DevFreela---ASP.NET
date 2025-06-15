using Azure;
using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Application.Repositories.GenericRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models.Updates;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
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

        public async Task<SimpleResponseModel> ChangePasswordGenericAsync(int UserId, string OldPassword, string NewPassword)
        {
            SimpleResponseModel Response = new SimpleResponseModel();

            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == UserId);

                if (user is null)
                {
                    Response.Message = "Usuário não encontrado.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }

                if (string.IsNullOrEmpty(OldPassword) || string.IsNullOrEmpty(NewPassword))
                {
                    Response.Message = "Um dos campos de senha estão vazios.";
                    Response.Status = ResponseStatusEnum.Error;
                    return Response;
                }


                var Samepassword = await _dbContext.Users.AnyAsync(u => u.Id == UserId && u.Password == NewPassword);

                if (Samepassword)
                {
                    Response.Status = ResponseStatusEnum.Error;
                    Response.Message = "A nova senha não pode ser a mesma que a atual.";
                    return Response;
                }

                user.ChangePassword(NewPassword);
                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();
                return Response;
            }
            catch (Exception ex)
            {
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                Response.Status = ResponseStatusEnum.Error;
                return Response;
            }
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
