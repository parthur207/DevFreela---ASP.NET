using DevFreela.Application.DTOs;
using DevFreela.Domain.Models;

namespace DevFreela.Application.Interfaces
{
    public interface ISkillInterface
    {
        Task<ResponseModel<List<SkillDTO>>> GetAllSkillsAsync();

        Task<SimpleResponseModel> InsertSkill(CreateSkillModel Model);
    }
}
