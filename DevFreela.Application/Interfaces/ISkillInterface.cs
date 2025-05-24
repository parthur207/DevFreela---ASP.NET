using DevFreela.Domain.Models;

namespace DevFreela.Application.Interfaces
{
    public interface ISkillInterface
    {
        Task<ResponseModel<List<(int Id, string Description)>>> GetAllSkillsAsync();

        Task<SimpleResponseModel> InsetSkill(CreateSkillModel Model);
    }
}
