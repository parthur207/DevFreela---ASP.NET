using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.FreelancerRepository
{
    public interface IFreelancerUserSkillRepository
    {
        Task<SimpleResponseModel> CreateUserSkillAsync(int UserId, UserSkillEntity Entity);
    }
}
