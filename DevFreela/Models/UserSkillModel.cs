using DevFreela.Entities;

namespace DevFreela.Models
{
    public class UserSkillModel
    {
        public int[] SkillsIds { get; set; }

        public int Id{ get; set; }



        public UserSkillEntity ToUserSkillEntity(UserSkillModel Model)
        => new(SkillsIds=Model.);
    }
}