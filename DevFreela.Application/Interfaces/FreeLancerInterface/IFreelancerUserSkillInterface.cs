using DevFreela.Application.Models;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.FreeLancerInterface
{
    public interface IFreelancerUserSkillInterface
    {
        Task<SimpleResponseModel> CreateUserSkill(CreateUserSkillModel model);
    }
}
