using DevFreela.Application.DTOs;
using DevFreela.Domain.Models;
using DevFreela.Domain.Models.ResponsePattern;

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface ISkillInterface
    {
        Task<ResponseModel<List<SkillDTO>>> GetAllSkillsAsync();

        Task<SimpleResponseModel> CreateSkillAsync(CreateSkillModel Model);
    }
}
