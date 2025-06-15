
using DevFreela.Domain.Enums;

namespace DevFreela.Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public UserEntity(string fullName, string email, string password, DateTime birthDate, RolesTypesEnum role)
            : base()
        {
            FullName = fullName;
            Email = email;
            Password = password;
            BirthDate = birthDate;
            Role= role;
            Skills = [];
            Comments = [];
            OwnedProjects = [];
            FreeLancerProjects = [];
            
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime BirthDate { get; private set; }
        public RolesTypesEnum Role { get; private set; } 
        public List<UserSkillEntity> Skills { get; private set; }
        public List<ProjectCommentEntity> Comments { get; private set; }
        public List<ProjectEntity> OwnedProjects { get; private set; }//Client
        public List<ProjectEntity> FreeLancerProjects { get; private set; }//Freelancer

        public void ChangePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}
