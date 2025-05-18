namespace DevFreela.Domain.Entities
{
    public class UserSkillEntity : BaseEntity
    {
        public UserSkillEntity(int idUser, int idSkill) 
            : base()
        {
            IdUser = idUser;
            IdSkill = idSkill;
        }

        public int IdUser { get; private set; }

        public UserEntity User { get; private set; }
        public int IdSkill{ get; private set; }
        public SkillEntity Skill { get; set; }
    }
}
