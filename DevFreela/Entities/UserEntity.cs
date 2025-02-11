namespace DevFreela.Entities
{
    public class UserEntity : BaseEntity
    {
        public UserEntity(string fullName, string email, DateTime birthDate) 
            : base()
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;
            Skills = [];
            OwnedProjects = [];
            FreeLancerProjects = [];
            Comments = [];
        }

        public  string FullName { get; private set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; private set; }

        public bool Active { get; private set; }

        public List<UserSkillEntity> Skills { get; private set; }

        public List<ProjectCommentEntity> Comments { get; private set; }

        public List<ProjectEntity> OwnedProjects { get; private set; }

        public List<ProjectEntity> FreeLancerProjects { get; private set; }
    }
}
