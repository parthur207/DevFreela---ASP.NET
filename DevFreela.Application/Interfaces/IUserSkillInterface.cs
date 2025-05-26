using DevFreela.Application.Models;
using DevFreela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces
{
    public interface IUserSkillInterface
    {
        Task<SimpleResponseModel> CreateUserSkillAsync(UserSkillModel model); 
    }
}
