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
    public interface IUserGenericRepository
    {
        Task<ResponseModel<(int, RolesTypesEnum)>> LoginGenericAsync(UserEntity Entity);
        Task<SimpleResponseModel> RegisterGenericAsync(UserEntity Entity);
        Task<SimpleResponseModel> ChangePasswordGenericAsync(int UserId, UserEntity Entity);
    }
}