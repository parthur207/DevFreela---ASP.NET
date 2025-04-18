using DevFreela.Entities;

namespace DevFreela.Models
{
    public class SkillViewModel
    {
        public SkillViewModel(int id, string user, List<string> skills)
        {
            Id = id;
            User = user;
            Skills = skills;
        }

        public int Id { get; set; }

        public string? User { get; set; }

        public List<string> Skills { get; set; }

        public static SkillViewModel ToSkillViewModel(SkillEntity entity)
        {
            var skills = entity.UserSkills.Select(x => x.Skill.Description).ToList();
            var User = entity.UserSkills.SingleOrDefault().User.FullName.ToString();
            return new SkillViewModel(entity.Id, User, skills);
        }
    }
}
