using DevFreela.Entities;

namespace DevFreela.Models
{
    public class CreateSkillModel
    {

        public string Description { get; set; }

        public SkillEntity ToSkillModel()
       => new(Description);
    }
}
