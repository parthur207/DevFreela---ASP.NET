using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.Generic
{
    public interface IAuthRespository
    {
        Task<SimpleResponseModel> GenericLoginAync(UserEntity Entity);

        Task<SimpleResponseModel> GenericRegister(UserEntity Entity);
    }
}
