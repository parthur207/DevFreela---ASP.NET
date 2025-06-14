using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models.Updates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.GenericRepository
{
    public interface UserGenericRepository
    {
        Task<ResponseModel<(int, RolesTypesEnum)>> LoginGenericAsync(LoginModel model);
        Task<SimpleResponseModel> RegisterGenericAsync(CreateUserModel model);
        Task<SimpleResponseModel> ChangePasswordGenericAsync(int UserId, UpdatePasswordModel model);
    }
}