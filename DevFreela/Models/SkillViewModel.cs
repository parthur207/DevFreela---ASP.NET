using DevFreela.Controllers;
using DevFreela.Entities;

namespace DevFreela.Models
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, List<string> skills)
        {
            Id = id;
            Skills = skills;
        }

        public int Id { get; set; }

        public List<string> Skills { get; set; }

        public static SkillViewModel ToSkillViewModel(SkillEntity entity)
        {
            return new SkillViewModel(entity.Id, new List<string> { entity.Description });
        }
    }
}
