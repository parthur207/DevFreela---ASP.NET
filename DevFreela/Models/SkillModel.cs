using DevFreela.Entities;

namespace DevFreela.Models
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
