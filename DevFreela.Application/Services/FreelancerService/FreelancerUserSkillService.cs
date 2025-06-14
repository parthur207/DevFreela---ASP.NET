using DevFreela.Application.Interfaces.FreeLancerInterface;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.FreelancerService
{
    internal class FreelancerUserSkillService : IFreelancerUserSkillInterface
    {
        public Task<SimpleResponseModel> CreateUserSkill(int UserId, CreateUserSkillModel model)
        {
            throw new NotImplementedException();
        }
    }
}
