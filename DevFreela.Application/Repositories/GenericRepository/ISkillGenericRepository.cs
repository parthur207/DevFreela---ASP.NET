using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.GenericRepository
{
    public interface ISkillGenericRepository
    {
        Task<ResponseModel<List<SkillEntity>>> GetAllSkillsAsync();

        Task<SimpleResponseModel> CreateSkillAsync(SkillEntity Entity);
    }
}
