using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Models;
using DevFreela.Domain.Models.ResponsePattern;

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface IGenericSkillInterface
    {
        Task<ResponseModel<List<SkillDTO>>> GetAllSkillsAsync();

        Task<SimpleResponseModel> CreateSkillAsync(CreateSkillModel Model);
    }
}
