using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Models
{
    public class SkillModel
    {

        public SkillModel(string description)
        {
            Description = description;
        }
        public string Description { get; set; }
    }
}
