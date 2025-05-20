using DevFreela.Domain.Entities;

namespace DevFreela.Application.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string fullName, string email, DateTime birthDate, List<string> skills)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Skills = skills;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<string> Skills { get; private set; }

        public static UserViewModel ToUserViewModel(UserEntity entity)
        {

            var skills = entity.Skills.Select(x => x.Skill.Description).ToList();
            return new UserViewModel(entity.FullName, entity.Email, entity.BirthDate,skills);
        }
    }
}
