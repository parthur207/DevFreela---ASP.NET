using DevFreela.Models;

namespace DevFreela.Entities
{
    public class SkillEntity : BaseEntity
    {
        public SkillEntity(string description)
        :base()
        {
            Description = description;
        }
        public string Description { get; private set; }

        public List<UserSkillEntity> UserSkills { get; set; }

    }
}
