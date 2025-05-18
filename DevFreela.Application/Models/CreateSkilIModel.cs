using DevFreela.Domain.Entities;

namespace DevFreela.Application.Models
{
    public class CreateSkillModel
    {

        public string Description { get; set; }

        public SkillEntity ToSkillEntity()
       => new(Description);
    }
}
