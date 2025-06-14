using DevFreela.Application.Interfaces.GenericInterface;
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

namespace DevFreela.Application.Services.GenericService
{
    internal class UserGenericService : IUserGenericInterface
    {
        public Task<SimpleResponseModel> ChangePasswordGeneric(int UserId, UpdatePasswordModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<(int, RolesTypesEnum)>> LoginGeneric(LoginModel model)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> RegisterGeneric(CreateUserModel model)
        {
            throw new NotImplementedException();
        }
    }
}
