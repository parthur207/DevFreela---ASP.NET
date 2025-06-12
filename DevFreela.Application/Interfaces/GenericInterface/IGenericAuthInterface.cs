using DevFreela.Domain.Models;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface IGenericAuthInterface
    {
        Task<SimpleResponseModel> GenericLogin(LoginModel model);
        Task<SimpleResponseModel> GenericRegister(CreateUserModel model);

    }
}
