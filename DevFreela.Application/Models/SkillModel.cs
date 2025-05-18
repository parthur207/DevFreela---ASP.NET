using DevFreela.Domain.Entities;

namespace DevFreela.Application.Models
{
    public class SkillModel
    {

        public SkillModel(string description)
        {
            Description = description;
        }
        public string Description { get; set; }

        public SkillEntity ToSkillEntity()
            => new (Description );
    }
}
