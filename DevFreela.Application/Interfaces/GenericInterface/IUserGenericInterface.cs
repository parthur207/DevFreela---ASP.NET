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

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface IUserGenericInterface
    {
        Task<ResponseModel<(int, RolesTypesEnum)>> LoginGeneric(LoginModel model);
        Task<SimpleResponseModel> RegisterGeneric(CreateUserModel model);
        Task<SimpleResponseModel> ChangePasswordGeneric(int UserId, UpdatePasswordModel model);

        //Task<SimpleResponseModel> PostProfilePicture();

    }
}
