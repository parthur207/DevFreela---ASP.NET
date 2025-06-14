using DevFreela.Domain.Models;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface IUserGenericInterface
    {
        Task<SimpleResponseModel> LoginGeneric(LoginModel model);
        Task<SimpleResponseModel> RegisterRegister(CreateUserModel model);

        Task<SimpleResponseModel> ChangePassword(UpdatePasswordModel model);

        //Task<SimpleResponseModel> PostProfilePicture();

    }
}
