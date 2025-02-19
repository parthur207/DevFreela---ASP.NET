using DevFreela.Entities;

namespace DevFreela.Models
{
    public class UsersSkillsModel
    {
        public int[] SkillsIds { get; set; }

        public int Id{ get; set; }

        public SkillEntity ToSk()
        {

        }
    }
}