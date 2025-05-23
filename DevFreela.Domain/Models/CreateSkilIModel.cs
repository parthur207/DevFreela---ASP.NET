using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Models
{
    public class CreateSkillModel
    {

        public string Description { get; set; }

        public SkillEntity ToSkillEntity()
       => new(Description);
    }
}
