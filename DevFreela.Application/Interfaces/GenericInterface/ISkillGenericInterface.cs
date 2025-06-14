using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface ISkillGenericInterface
    {
        Task<ResponseModel<List<SkillDTO>>> GetAllSkills();

        Task<SimpleResponseModel> CreateSkill(CreateSkillModel Model);
    }
}
