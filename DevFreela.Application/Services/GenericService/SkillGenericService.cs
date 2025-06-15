using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.GenericService
{
    internal class SkillGenericService : ISkillGenericInterface
    {
        public Task<SimpleResponseModel> CreateSkill(CreateSkillModel Model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<AdminFreelancerSkillDTO>>> GetAllSkills()
        {
            throw new NotImplementedException();
        }
    }
}
