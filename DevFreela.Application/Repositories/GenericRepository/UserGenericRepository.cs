using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.GenericRepository
{
    public interface UserGenericRepository
    {
        Task<SimpleResponseModel> LoginGenericAsync(UserEntity Entity);

        Task<SimpleResponseModel> RegisterGenericAsync(UserEntity Entity);
    }
}
